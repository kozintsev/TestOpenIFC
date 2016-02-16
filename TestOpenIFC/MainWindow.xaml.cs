using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using Xbim.Ifc2x3.ActorResource;
using Xbim.Ifc2x3.CostResource;
using Xbim.Ifc2x3.DateTimeResource;
using Xbim.Ifc2x3.Extensions;
using Xbim.Ifc2x3.ExternalReferenceResource;
using Xbim.Ifc2x3.GeometricConstraintResource;
using Xbim.Ifc2x3.GeometricModelResource;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MaterialResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.PresentationOrganizationResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.ProfileResource;
using Xbim.Ifc2x3.PropertyResource;
using Xbim.Ifc2x3.QuantityResource;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc2x3.SharedBldgElements;
using Xbim.Ifc2x3.TimeSeriesResource;
using Xbim.Ifc2x3.UtilityResource;
using Xbim.IO;
using Xbim.XbimExtensions.Interfaces;
using Xbim.XbimExtensions.SelectTypes;

namespace TestOpenIFC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Xbim модели, открытые для теста и для мержа
        private XbimModel testModel;
        private XbimModel firsModel;
        private XbimModel secondModel;
        // в переменную передаётся полный путь к файлу, который был открыт
        //private string ifcFilename;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddMessages(string messages)
        {
            MessagesList.Items.Add(messages);
        }
            

        private XbimModel GetXbimModelByFileName(string ifcFilename)
        {
            //tempModel = GetXbimModelByFileName(dlg.FileName);           
            var model = new XbimModel();
            try
            {
                string _temporaryXbimFileName = Path.GetTempFileName();
                //SetOpenedModelFileName(ifcFilename);
                model.CreateFrom(ifcFilename, _temporaryXbimFileName, null, true);
                labelDBname.Content = model.IfcProject.Name.ToString();
                labelGeometriesCount.Content = model.IfcProject.Phase.ToString();
                if (model != null)
                {
                    AddMessages("IFC file: " + ifcFilename + " correct");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка" + ex.Message);
                model = null;
            }
            return model;
        }

        private string CreateOpenFileDialog()
        {
            string filename = String.Empty;
            var dlg = new OpenFileDialog();
            dlg.Filter = "IFC Files|;*.ifc;*.ifcxml;*.ifczip"; // Filter files by extension
            dlg.FileOk += delegate (object sender, System.ComponentModel.CancelEventArgs e)
            {
                //var dlg = sender as OpenFileDialog;
                if (dlg != null)
                {
                    filename = dlg.FileName;          
                }
            };
            //Dlg_FileOk;
            dlg.ShowDialog(this);
            return filename;
        }
           
        private void btnTest_Click(object sender, RoutedEventArgs e)
        {
            testModel = GetXbimModelByFileName(CreateOpenFileDialog());

        }

        private void btnOpenIFCOne_Click(object sender, RoutedEventArgs e)
        {
            firsModel = GetXbimModelByFileName(CreateOpenFileDialog());
        }

        private void btnOpenIFCTwo_Click(object sender, RoutedEventArgs e)
        {
            secondModel = GetXbimModelByFileName(CreateOpenFileDialog());
        }


        /// <summary>
        /// Sets up the basic parameters any model must provide, units, ownership etc
        /// </summary>
        /// <param name="projectName">Name of the project</param>
        /// <returns></returns>
        private XbimModel CreateandInitModel(string projectName)
        {
            XbimModel model = XbimModel.CreateModel(projectName + ".xBIM"); //create an empty model

            //Begin a transaction as all changes to a model are transacted
            using (XbimReadWriteTransaction txn = model.BeginTransaction("Initialise Model"))
            {
                //do once only initialisation of model application and editor values
                model.DefaultOwningUser.ThePerson.GivenName = "";
                model.DefaultOwningUser.ThePerson.FamilyName = "";
                model.DefaultOwningUser.TheOrganization.Name = "ASCON";
                model.DefaultOwningApplication.ApplicationIdentifier = "ASCON inc.";
                model.DefaultOwningApplication.ApplicationDeveloper.Name = "ASCON Ltd.";
                model.DefaultOwningApplication.ApplicationFullName = "Ifc Pilot ICE extension";
                model.DefaultOwningApplication.Version = "2.0.1";

                //set up a project and initialise the defaults

                var project = model.Instances.New<IfcProject>();
                project.Initialize(ProjectUnits.SIUnitsUK);
                project.Name = "Global Project";
                project.OwnerHistory.OwningUser = model.DefaultOwningUser;
                project.OwnerHistory.OwningApplication = model.DefaultOwningApplication;

                //validate and commit changes
                if (model.Validate(txn.Modified(), Console.Out) == 0)
                {
                    txn.Commit();
                    return model;
                }
            }
            return null; //failed so return nothing
        }

        private IfcBuilding AddBuilding(XbimModel model, IfcBuilding _building)
        {
            using (XbimReadWriteTransaction txn = model.BeginTransaction("Add Building"))
            {
                //var building = model.Instances.New<IfcBuilding>();
                //var building = model.InsertCopy<IfcBuilding>(_building, txn);
                //_building.Bind
                model.IfcProject.AddBuilding(_building);
                //validate and commit changes
                if (model.Validate(txn.Modified(), Console.Out) == 0)
                {
                    txn.Commit();
                    return _building;
                }
            }
            return null;
        }
        
        /// <summary>
        /// Copy building
        /// </summary>
        /// <param model="model"></param>
        /// <param IfcBuilding="_building"></param>
        /// <returns></returns>
        private IfcBuilding CopyBuilding(XbimModel model, IfcBuilding _building)
        {
            using (XbimReadWriteTransaction txn = model.BeginTransaction("Create Building"))
            {
                var building = model.Instances.New<IfcBuilding>();
                building.GlobalId = _building.GlobalId;
                building.Name = _building.Name;
                building.OwnerHistory.OwningUser = model.DefaultOwningUser;
                building.OwnerHistory.OwningApplication = model.DefaultOwningApplication;
                //building.ElevationOfRefHeight = elevHeight;
                building.CompositionType = _building.CompositionType; //IfcElementCompositionEnum.ELEMENT;
                building.ObjectPlacement = model.Instances.New<IfcLocalPlacement>();

                var  localPlacement =  building.ObjectPlacement as IfcLocalPlacement;
                var _localPlacement = _building.ObjectPlacement as IfcLocalPlacement;

                if (localPlacement != null && localPlacement.RelativePlacement == null)
                {

                    localPlacement.RelativePlacement = model.Instances.New<IfcAxis2Placement3D>();
                    //IfcAxis2Placement axis = _localPlacement.RelativePlacement;
                    var  placement = localPlacement.RelativePlacement as IfcAxis2Placement3D;
                    var _placement = _localPlacement.RelativePlacement as IfcAxis2Placement3D;
                    //placement.Axis = _placement.Axis;
                    //placement.Location = _placement.Location;
                    //placement.RefDirection = _placement.RefDirection;
                    placement.SetNewLocation(_placement.Location.X, _placement.Location.Y, _placement.Location.Z);
                }

                model.IfcProject.AddBuilding(building);
                //validate and commit changes
                if (model.Validate(txn.Modified(), Console.Out) == 0)
                {
                    txn.Commit();
                    return building;
                }

            }
            return null;
        }

        

        private void AddProductInBuildingStorey(XbimModel model, IfcBuildingStorey _buildingStorey, IfcProduct _prod)
        {
            using (XbimReadWriteTransaction txn = model.BeginTransaction())
            {
                //if (_prod is IfcSpatialStructureElement)
                try
                {
                    _buildingStorey.AddElement(_prod);
                    txn.Commit();
                }
                catch
                {
                    //MessageBox.Show(_prod.GetType().Name);
                }

            }
        }

        private void AddProduct(XbimModel model, IfcBuilding _building, IfcProduct _prod)
        {
            using (XbimReadWriteTransaction txn = model.BeginTransaction("Add Product"))
            {
                //if (_prod is IfcSpatialStructureElement)
                try
                {
                    _building.AddElement(_prod);
                    txn.Commit();
                }
                catch
                {
                    //MessageBox.Show(_prod.GetType().Name);
                }
                
            }
        }

        private IfcBuilding CreateBuilding(XbimModel model, string name)
        {
            using (XbimReadWriteTransaction txn = model.BeginTransaction("Create Building"))
            {
                var building = model.Instances.New<IfcBuilding>();
                building.Name = name;
                building.OwnerHistory.OwningUser = model.DefaultOwningUser;
                building.OwnerHistory.OwningApplication = model.DefaultOwningApplication;
                //building.ElevationOfRefHeight = elevHeight;
                building.CompositionType = IfcElementCompositionEnum.ELEMENT;

                building.ObjectPlacement = model.Instances.New<IfcLocalPlacement>();
                var localPlacement = building.ObjectPlacement as IfcLocalPlacement;

                if (localPlacement != null && localPlacement.RelativePlacement == null)
                {

                    localPlacement.RelativePlacement = model.Instances.New<IfcAxis2Placement3D>();
                    var placement = localPlacement.RelativePlacement as IfcAxis2Placement3D;
                    placement.SetNewLocation(0.0, 0.0, 0.0);
                }

                model.IfcProject.AddBuilding(building);
                //validate and commit changes
                if (model.Validate(txn.Modified(), Console.Out) == 0)
                {
                    txn.Commit();
                    return building;
                }

            }
            return null;
        }
        /// <summary>
        /// This creates a wall and it's geometry, many geometric representations are possible and extruded rectangular footprint is chosen as this is commonly used for standard case walls
        /// </summary>
        /// <param name="model"></param>
        /// <param name="length">Length of the rectangular footprint</param>
        /// <param name="width">Width of the rectangular footprint (width of the wall)</param>
        /// <param name="height">Height to extrude the wall, extrusion is vertical</param>
        /// <returns></returns>
        private IfcWallStandardCase CreateWall(XbimModel model, double length, double width, double height)
        {
            //
            //begin a transaction
            using (XbimReadWriteTransaction txn = model.BeginTransaction("Create Wall"))
            {
                var wall = model.Instances.New<IfcWallStandardCase>();
                wall.Name = "A Standard rectangular wall";

                // required parameters for IfcWall
                wall.OwnerHistory.OwningUser = model.DefaultOwningUser;
                wall.OwnerHistory.OwningApplication = model.DefaultOwningApplication;

                //represent wall as a rectangular profile
                var rectProf = model.Instances.New<IfcRectangleProfileDef>();
                rectProf.ProfileType = IfcProfileTypeEnum.AREA;
                rectProf.XDim = width;
                rectProf.YDim = length;

                var insertPoint = model.Instances.New<IfcCartesianPoint>();
                insertPoint.SetXY(0, 400); //insert at arbitrary position
                rectProf.Position = model.Instances.New<IfcAxis2Placement2D>();
                rectProf.Position.Location = insertPoint;

                //model as a swept area solid
                var body = model.Instances.New<IfcExtrudedAreaSolid>();
                body.Depth = height;
                body.SweptArea = rectProf;
                body.ExtrudedDirection = model.Instances.New<IfcDirection>();
                body.ExtrudedDirection.SetXYZ(0, 0, 1);

                //parameters to insert the geometry in the model
                var origin = model.Instances.New<IfcCartesianPoint>();
                origin.SetXYZ(0, 0, 0);
                body.Position = model.Instances.New<IfcAxis2Placement3D>();
                body.Position.Location = origin;

                //Create a Definition shape to hold the geometry
                var shape = model.Instances.New<IfcShapeRepresentation>();
                shape.ContextOfItems = model.IfcProject.ModelContext();
                shape.RepresentationType = "SweptSolid";
                shape.RepresentationIdentifier = "Body";
                shape.Items.Add(body);

                //Create a Product Definition and add the model geometry to the wall
                var rep = model.Instances.New<IfcProductDefinitionShape>();
                rep.Representations.Add(shape);
                wall.Representation = rep;

                //now place the wall into the model
                var lp = model.Instances.New<IfcLocalPlacement>();
                var ax3D = model.Instances.New<IfcAxis2Placement3D>();
                ax3D.Location = origin;
                ax3D.RefDirection = model.Instances.New<IfcDirection>();
                ax3D.RefDirection.SetXYZ(0, 1, 0);
                ax3D.Axis = model.Instances.New<IfcDirection>();
                ax3D.Axis.SetXYZ(0, 0, 1);
                lp.RelativePlacement = ax3D;
                wall.ObjectPlacement = lp;


                // Where Clause: The IfcWallStandard relies on the provision of an IfcMaterialLayerSetUsage 
                var ifcMaterialLayerSetUsage = model.Instances.New<IfcMaterialLayerSetUsage>();
                var ifcMaterialLayerSet = model.Instances.New<IfcMaterialLayerSet>();
                var ifcMaterialLayer = model.Instances.New<IfcMaterialLayer>();
                ifcMaterialLayer.LayerThickness = 10;
                ifcMaterialLayerSet.MaterialLayers.Add(ifcMaterialLayer);
                ifcMaterialLayerSetUsage.ForLayerSet = ifcMaterialLayerSet;
                ifcMaterialLayerSetUsage.LayerSetDirection = IfcLayerSetDirectionEnum.AXIS2;
                ifcMaterialLayerSetUsage.DirectionSense = IfcDirectionSenseEnum.NEGATIVE;
                ifcMaterialLayerSetUsage.OffsetFromReferenceLine = 150;

                // Add material to wall
                var material = model.Instances.New<IfcMaterial>();
                material.Name = "some material";
                var ifcRelAssociatesMaterial = model.Instances.New<IfcRelAssociatesMaterial>();
                ifcRelAssociatesMaterial.RelatingMaterial = material;
                ifcRelAssociatesMaterial.RelatedObjects.Add(wall);

                ifcRelAssociatesMaterial.RelatingMaterial = ifcMaterialLayerSetUsage;

                // IfcPresentationLayerAssignment is required for CAD presentation in IfcWall or IfcWallStandardCase
                var ifcPresentationLayerAssignment = model.Instances.New<IfcPresentationLayerAssignment>();
                ifcPresentationLayerAssignment.Name = "some ifcPresentationLayerAssignment";
                ifcPresentationLayerAssignment.AssignedItems.Add(shape);


                // linear segment as IfcPolyline with two points is required for IfcWall
                var ifcPolyline = model.Instances.New<IfcPolyline>();
                var startPoint = model.Instances.New<IfcCartesianPoint>();
                startPoint.SetXY(0, 0);
                var endPoint = model.Instances.New<IfcCartesianPoint>();
                endPoint.SetXY(4000, 0);
                ifcPolyline.Points.Add(startPoint);
                ifcPolyline.Points.Add(endPoint);

                var shape2D = model.Instances.New<IfcShapeRepresentation>();
                shape2D.ContextOfItems = model.IfcProject.ModelContext();
                shape2D.RepresentationIdentifier = "Axis";
                shape2D.RepresentationType = "Curve2D";
                shape2D.Items.Add(ifcPolyline);
                rep.Representations.Add(shape2D);


                //validate write any errors to the console and commit if ok, otherwise abort

                //if (model.Validate(txn.Modified(), Console.Out) == 0)
                //{
                    txn.Commit();
                    return wall;
                //}
            }
            return null;
        }
        /// <summary>
        /// Add some properties to the wall,
        /// </summary>
        /// <param name="model">XbimModel</param>
        /// <param name="wall"></param>
        private void AddPropertiesToWall(XbimModel model, IfcWallStandardCase wall)
        {
            using (XbimReadWriteTransaction txn = model.BeginTransaction("Create Wall"))
            {
                IfcOwnerHistory ifcOwnerHistory = model.IfcProject.OwnerHistory; //we just use the project owner history for the properties, saves creating one
                CreateElementQuantity(model, wall, ifcOwnerHistory);
                CreateSimpleProperty(model, wall, ifcOwnerHistory);

                //if (model.Validate(txn.Modified(), Console.Out) == 0)
                //{
                txn.Commit();
                //}   
            }
        }

        private void CreateSimpleProperty(XbimModel model, IfcWallStandardCase wall, IfcOwnerHistory ifcOwnerHistory)
        {
            var ifcPropertySingleValue = model.Instances.New<IfcPropertySingleValue>(psv =>
            {
                psv.Name = "IfcPropertySingleValue:Time";
                psv.Description = "";
                psv.NominalValue = new IfcTimeMeasure(150.0);
                psv.Unit = model.Instances.New<IfcSIUnit>(siu =>
                {
                    siu.UnitType = IfcUnitEnum.TIMEUNIT;
                    siu.Name = IfcSIUnitName.SECOND;
                    siu.Dimensions = model.Instances.New<IfcDimensionalExponents>(de =>
                    {
                        de.LengthExponent = 0;
                        de.MassExponent = 0;
                        de.TimeExponent = 1;
                        de.ElectricCurrentExponent = 0;
                        de.ThermodynamicTemperatureExponent = 0;
                        de.AmountOfSubstanceExponent = 0;
                        de.LuminousIntensityExponent = 0;
                    });
                });
            });
            var ifcPropertyEnumeratedValue = model.Instances.New<IfcPropertyEnumeratedValue>(pev =>
            {
                pev.Name = "IfcPropertyEnumeratedValue:Music";
                pev.EnumerationReference = model.Instances.New<IfcPropertyEnumeration>(pe =>
                {
                    pe.Name = "Notes";
                    pe.EnumerationValues.Add(new IfcLabel("Do"));
                    pe.EnumerationValues.Add(new IfcLabel("Re"));
                    pe.EnumerationValues.Add(new IfcLabel("Mi"));
                    pe.EnumerationValues.Add(new IfcLabel("Fa"));
                    pe.EnumerationValues.Add(new IfcLabel("So"));
                    pe.EnumerationValues.Add(new IfcLabel("La"));
                    pe.EnumerationValues.Add(new IfcLabel("Ti"));
                });
                pev.EnumerationValues.Add(new IfcLabel("Do"));
                pev.EnumerationValues.Add(new IfcLabel("Re"));
                pev.EnumerationValues.Add(new IfcLabel("Mi"));

            });
            var ifcPropertyBoundedValue = model.Instances.New<IfcPropertyBoundedValue>(pbv =>
            {
                pbv.Name = "IfcPropertyBoundedValue:Mass";
                pbv.Description = "";
                pbv.UpperBoundValue = new IfcMassMeasure(5000.0);
                pbv.LowerBoundValue = new IfcMassMeasure(1000.0);
                pbv.Unit = model.Instances.New<IfcSIUnit>(siu =>
                {
                    siu.UnitType = IfcUnitEnum.MASSUNIT;
                    siu.Name = IfcSIUnitName.GRAM;
                    siu.Prefix = IfcSIPrefix.KILO;
                    siu.Dimensions = model.Instances.New<IfcDimensionalExponents>(de =>
                    {
                        de.LengthExponent = 0;
                        de.MassExponent = 1;
                        de.TimeExponent = 0;
                        de.ElectricCurrentExponent = 0;
                        de.ThermodynamicTemperatureExponent = 0;
                        de.AmountOfSubstanceExponent = 0;
                        de.LuminousIntensityExponent = 0;
                    });
                });
            });

            var definingValues = new List<IfcReal> { new IfcReal(100.0), new IfcReal(200.0), new IfcReal(400.0), new IfcReal(800.0), new IfcReal(1600.0), new IfcReal(3200.0), };
            var definedValues = new List<IfcReal> { new IfcReal(20.0), new IfcReal(42.0), new IfcReal(46.0), new IfcReal(56.0), new IfcReal(60.0), new IfcReal(65.0), };
            var ifcPropertyTableValue = model.Instances.New<IfcPropertyTableValue>(ptv =>
            {
                ptv.Name = "IfcPropertyTableValue:Sound";
                foreach (var item in definingValues)
                {
                    ptv.DefiningValues.Add(item);
                }
                foreach (var item in definedValues)
                {
                    ptv.DefinedValues.Add(item);
                }
                ptv.DefinedUnit = model.Instances.New<IfcContextDependentUnit>(cd =>
                {
                    cd.Dimensions = model.Instances.New<IfcDimensionalExponents>(de =>
                    {
                        de.LengthExponent = 0;
                        de.MassExponent = 0;
                        de.TimeExponent = 0;
                        de.ElectricCurrentExponent = 0;
                        de.ThermodynamicTemperatureExponent = 0;
                        de.AmountOfSubstanceExponent = 0;
                        de.LuminousIntensityExponent = 0;
                    });
                    cd.UnitType = IfcUnitEnum.FREQUENCYUNIT;
                    cd.Name = "dB";
                });


            });

            var listValues = new List<IfcLabel> { new IfcLabel("Red"), new IfcLabel("Green"), new IfcLabel("Blue"), new IfcLabel("Pink"), new IfcLabel("White"), new IfcLabel("Black"), };
            var ifcPropertyListValue = model.Instances.New<IfcPropertyListValue>(plv =>
            {
                plv.Name = "IfcPropertyListValue:Colours";
                foreach (var item in listValues)
                {
                    plv.ListValues.Add(item);
                }
            });

            var ifcMaterial = model.Instances.New<IfcMaterial>(m =>
            {
                m.Name = "Brick";
            });
            var ifcPrValueMaterial = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:Material";
                prv.PropertyReference = ifcMaterial;
            });

            var ifcPrValuePerson = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:Person";
                prv.PropertyReference = ifcOwnerHistory.OwningUser.ThePerson;
            });

            var ifcDateAndTime = model.Instances.New<IfcDateAndTime>(dt =>
            {
                dt.DateComponent = model.Instances.New<IfcCalendarDate>(cd =>
                {
                    cd.DayComponent = 25;
                    cd.MonthComponent = 3;
                    cd.YearComponent = 2013;
                });
                dt.TimeComponent = model.Instances.New<IfcLocalTime>(lt =>
                {
                    lt.HourComponent = 10;
                    lt.MinuteComponent = 30;
                    lt.SecondComponent = 0;
                });
            });
            var ifcPrValueDateTime = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:DateAndTime";
                prv.PropertyReference = ifcDateAndTime;
            });

            var ifcMaterialList = model.Instances.New<IfcMaterialList>(ml =>
            {
                ml.Materials.Add(ifcMaterial);
                ml.Materials.Add(model.Instances.New<IfcMaterial>(m => { m.Name = "Cavity"; }));
                ml.Materials.Add(model.Instances.New<IfcMaterial>(m => { m.Name = "Block"; }));
            });
            var ifcPrValueMatList = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:MaterialList";
                prv.PropertyReference = ifcMaterialList;
            });

            var ifcPrValueOrg = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:Organization";
                prv.PropertyReference = ifcOwnerHistory.OwningUser.TheOrganization;
            });

            var ifcPrValueDate = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:Date";
                prv.PropertyReference = ifcDateAndTime.DateComponent;
            });

            var ifcPrValueTime = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:Time";
                prv.PropertyReference = ifcDateAndTime.TimeComponent;
            });

            var ifcPrValuePersonOrg = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:PersonOrganization";
                prv.PropertyReference = ifcOwnerHistory.OwningUser;
            });

            var ifcMaterialLayer = model.Instances.New<IfcMaterialLayer>(ml =>
            {
                ml.Material = ifcMaterial;
                ml.LayerThickness = 100.0;
            });
            var ifcPrValueMatLayer = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:MaterialLayer";
                prv.PropertyReference = ifcMaterialLayer;
            });

            var ifcDocumentReference = model.Instances.New<IfcDocumentReference>(dr =>
            {
                dr.Name = "Document";
                dr.Location = "c://Documents//TheDoc.Txt";
            });
            var ifcPrValueRef = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:Document";
                prv.PropertyReference = ifcDocumentReference;
            });

            var ifcTimeSeries = model.Instances.New<IfcRegularTimeSeries>(ts =>
            {
                ts.Name = "Regular Time Series";
                ts.Description = "Time series of events";
                ts.StartTime = model.Instances.New<IfcCalendarDate>(cd =>
                {
                    cd.DayComponent = 01;
                    cd.MonthComponent = 1;
                    cd.YearComponent = 2013;
                });
                ts.EndTime = model.Instances.New<IfcCalendarDate>(cd =>
                {
                    cd.DayComponent = 01;
                    cd.MonthComponent = 3;
                    cd.YearComponent = 2013;
                });
                ts.TimeSeriesDataType = IfcTimeSeriesDataTypeEnum.CONTINUOUS;
                ts.DataOrigin = IfcDataOriginEnum.MEASURED;
                ts.TimeStep = 604800; //7 days in secs
            });

            var ifcPrValueTimeSeries = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:TimeSeries";
                prv.PropertyReference = ifcTimeSeries;
            });

            var ifcAddress = model.Instances.New<IfcPostalAddress>(a =>
            {
                a.InternalLocation = "Room 101";
                a.SetAddressLines(new[] { "12 New road", "DoxField" });
                a.Town = "Sunderland";
                a.PostalCode = "DL01 6SX";
            });
            var ifcPrValueAddress = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:Address";
                prv.PropertyReference = ifcAddress;
            });
            var ifcTelecomAddress = model.Instances.New<IfcTelecomAddress>(a =>
            {
                a.SetTelephoneNumbers(new[] { "01325 6589965" });
                a.SetElectronicMailAddress(new[] { "bob@bobsworks.com" });
            });
            var ifcPrValueTelecom = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:Telecom";
                prv.PropertyReference = ifcTelecomAddress;
            });

            var ifcCostValue = model.Instances.New<IfcCostValue>(cv =>
            {
                cv.Name = "Cost Value";
                cv.Description = "";
                cv.Value = new IfcMonetaryMeasure(155.0);
                cv.ApplicableDate = model.Instances.New<IfcCalendarDate>(cd =>
                {
                    cd.DayComponent = 02;
                    cd.MonthComponent = 02;
                    cd.YearComponent = 2013;
                });
                cv.FixedUntilDate = model.Instances.New<IfcCalendarDate>(cd =>
                {
                    cd.DayComponent = 31;
                    cd.MonthComponent = 12;
                    cd.YearComponent = 2013;
                });
                cv.CostType = "Annual rate of return";
                cv.Condition = "";
            });
            var ifcPrValueCostValue = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:CostValue";
                prv.PropertyReference = ifcCostValue;
            });


            var ifcEnvironmentalImpactValue = model.Instances.New<IfcEnvironmentalImpactValue>(cv =>
            {
                cv.Name = "Environmental Impact";
                cv.Description = "";
                cv.Value = model.Instances.New<IfcMeasureWithUnit>(mwu =>
                {
                    mwu.ValueComponent = new IfcReal(111.0);
                    mwu.UnitComponent = model.Instances.New<IfcSIUnit>(siu =>
                    {
                        siu.UnitType = IfcUnitEnum.LENGTHUNIT;
                        siu.Name = IfcSIUnitName.METRE;
                        siu.Dimensions = model.Instances.New<IfcDimensionalExponents>(de =>
                        {
                            de.LengthExponent = 1;
                            de.MassExponent = 0;
                            de.TimeExponent = 0;
                            de.ElectricCurrentExponent = 0;
                            de.ThermodynamicTemperatureExponent = 0;
                            de.AmountOfSubstanceExponent = 0;
                            de.LuminousIntensityExponent = 0;
                        });
                    });
                });
                cv.ApplicableDate = model.Instances.New<IfcCalendarDate>(cd =>
                {
                    cd.DayComponent = 02;
                    cd.MonthComponent = 02;
                    cd.YearComponent = 2013;
                });
                cv.FixedUntilDate = model.Instances.New<IfcCalendarDate>(cd =>
                {
                    cd.DayComponent = 31;
                    cd.MonthComponent = 12;
                    cd.YearComponent = 2013;
                });
                cv.ImpactType = "Embodied energy";
                cv.Category = IfcEnvironmentalImpactCategoryEnum.MANUFACTURE;
            });
            var ifcPrValueEnvironmentalImpact = model.Instances.New<IfcPropertyReferenceValue>(prv =>
            {
                prv.Name = "IfcPropertyReferenceValue:EnvironmentalImpact";
                prv.PropertyReference = ifcEnvironmentalImpactValue;
            });

            //lets create the IfcElementQuantity
            var ifcPropertySet = model.Instances.New<IfcPropertySet>(ps =>
            {
                ps.OwnerHistory = ifcOwnerHistory;
                ps.Name = "Test:IfcPropertySet";
                ps.Description = "Property Set";
                ps.HasProperties.Add(ifcPropertySingleValue);
                ps.HasProperties.Add(ifcPropertyEnumeratedValue);
                ps.HasProperties.Add(ifcPropertyBoundedValue);
                ps.HasProperties.Add(ifcPropertyTableValue);
                ps.HasProperties.Add(ifcPropertyListValue);
                ps.HasProperties.Add(ifcPrValueMaterial);
                ps.HasProperties.Add(ifcPrValuePerson);
                ps.HasProperties.Add(ifcPrValueDateTime);
                ps.HasProperties.Add(ifcPrValueMatList);
                ps.HasProperties.Add(ifcPrValueOrg);
                ps.HasProperties.Add(ifcPrValueDate);
                ps.HasProperties.Add(ifcPrValueTime);
                ps.HasProperties.Add(ifcPrValuePersonOrg);
                ps.HasProperties.Add(ifcPrValueMatLayer);
                ps.HasProperties.Add(ifcPrValueRef);
                ps.HasProperties.Add(ifcPrValueTimeSeries);
                ps.HasProperties.Add(ifcPrValueAddress);
                ps.HasProperties.Add(ifcPrValueTelecom);
                ps.HasProperties.Add(ifcPrValueCostValue);
                ps.HasProperties.Add(ifcPrValueEnvironmentalImpact);

            });

            //need to create the relationship
            model.Instances.New<IfcRelDefinesByProperties>(rdbp =>
            {
                rdbp.OwnerHistory = ifcOwnerHistory;
                rdbp.Name = "Property Association";
                rdbp.Description = "IfcPropertySet associated to wall";
                rdbp.RelatedObjects.Add(wall);
                rdbp.RelatingPropertyDefinition = ifcPropertySet;
            });
        }

        private void CreateElementQuantity(XbimModel model, IfcWallStandardCase wall, IfcOwnerHistory ifcOwnerHistory)
        {
            //Create a IfcElementQuantity
            //first we need a IfcPhysicalSimpleQuantity,first will use IfcQuantityArea
            var ifcQuantityArea = model.Instances.New<IfcQuantityArea>(qa =>
            {
                qa.Name = "IfcQuantityArea:Area";
                qa.Description = "";
                qa.Unit = model.Instances.New<IfcSIUnit>(siu =>
                {
                    siu.UnitType = IfcUnitEnum.AREAUNIT;
                    siu.Prefix = IfcSIPrefix.MILLI;
                    siu.Name = IfcSIUnitName.SQUARE_METRE;
                    siu.Dimensions = model.Instances.New<IfcDimensionalExponents>(de =>
                    {
                        de.LengthExponent = 1;
                        de.MassExponent = 0;
                        de.TimeExponent = 0;
                        de.ElectricCurrentExponent = 0;
                        de.ThermodynamicTemperatureExponent = 0;
                        de.AmountOfSubstanceExponent = 0;
                        de.LuminousIntensityExponent = 0;
                    });

                });
                qa.AreaValue = 100.0;

            });
            //next quantity IfcQuantityCount using IfcContextDependentUnit
            var ifcContextDependentUnit = model.Instances.New<IfcContextDependentUnit>(cd =>
            {
                cd.Dimensions = model.Instances.New<IfcDimensionalExponents>(de =>
                {
                    de.LengthExponent = 1;
                    de.MassExponent = 0;
                    de.TimeExponent = 0;
                    de.ElectricCurrentExponent = 0;
                    de.ThermodynamicTemperatureExponent = 0;
                    de.AmountOfSubstanceExponent = 0;
                    de.LuminousIntensityExponent = 0;
                });
                cd.UnitType = IfcUnitEnum.LENGTHUNIT;
                cd.Name = "Elephants";
            });
            var ifcQuantityCount = model.Instances.New<IfcQuantityCount>(qc =>
            {
                qc.Name = "IfcQuantityCount:Elephant";
                qc.CountValue = 12;
                qc.Unit = ifcContextDependentUnit;
            });


            //next quantity IfcQuantityLength using IfcConversionBasedUnit
            var ifcConversionBasedUnit = model.Instances.New<IfcConversionBasedUnit>(cbu =>
            {
                cbu.ConversionFactor = model.Instances.New<IfcMeasureWithUnit>(mu =>
                {
                    mu.ValueComponent = new IfcRatioMeasure(25.4);
                    mu.UnitComponent = model.Instances.New<IfcSIUnit>(siu =>
                    {
                        siu.UnitType = IfcUnitEnum.LENGTHUNIT;
                        siu.Prefix = IfcSIPrefix.MILLI;
                        siu.Name = IfcSIUnitName.METRE;
                    });

                });
                cbu.Dimensions = model.Instances.New<IfcDimensionalExponents>(de =>
                {
                    de.LengthExponent = 1;
                    de.MassExponent = 0;
                    de.TimeExponent = 0;
                    de.ElectricCurrentExponent = 0;
                    de.ThermodynamicTemperatureExponent = 0;
                    de.AmountOfSubstanceExponent = 0;
                    de.LuminousIntensityExponent = 0;
                });
                cbu.UnitType = IfcUnitEnum.LENGTHUNIT;
                cbu.Name = "Inch";
            });
            var ifcQuantityLength = model.Instances.New<IfcQuantityLength>(qa =>
            {
                qa.Name = "IfcQuantityLength:Length";
                qa.Description = "";
                qa.Unit = ifcConversionBasedUnit;
                qa.LengthValue = 24.0;
            });

            //lets create the IfcElementQuantity
            var ifcElementQuantity = model.Instances.New<IfcElementQuantity>(eq =>
            {
                eq.OwnerHistory = ifcOwnerHistory;
                eq.Name = "Test:IfcElementQuantity";
                eq.Description = "Measurement quantity";
                eq.Quantities.Add(ifcQuantityArea);
                eq.Quantities.Add(ifcQuantityCount);
                eq.Quantities.Add(ifcQuantityLength);
            });

            //need to create the relationship
            model.Instances.New<IfcRelDefinesByProperties>(rdbp =>
            {
                rdbp.OwnerHistory = ifcOwnerHistory;
                rdbp.Name = "Area Association";
                rdbp.Description = "IfcElementQuantity associated to wall";
                rdbp.RelatedObjects.Add(wall);
                rdbp.RelatingPropertyDefinition = ifcElementQuantity;
            });
        }

        private void TestAddInIFC(XbimModel model)
        {
            if (model != null)
            {
                var bildings = model.IfcProducts.OfType<IfcBuilding>();
                var buildingStories = model.IfcProducts.OfType<IfcBuildingStorey>();
                var buildingStory = buildingStories.FirstOrDefault<IfcBuildingStorey>(); //ToList<IfcBuildingStorey>()[0];
                var firstbilding = bildings.FirstOrDefault<IfcBuilding>();

                IfcWallStandardCase wall = CreateWall(model, 4000, 300, 2400);
                if (wall != null) AddPropertiesToWall(model, wall);
                if (buildingStory != null)
                    AddProductInBuildingStorey(model, buildingStory, wall);
                else if (firstbilding != null)
                    AddProduct(model, firstbilding, wall);
                else
                {
                    var newbilding  = CreateBuilding(model, "Building");
                    AddProduct(model, newbilding, wall);
                }
                firsModel.SaveAs("test.ifc");
            }
        }

        private IfcBuildingStorey CopyBuildingStory(XbimModel model, IfcBuildingStorey _buildingStory, IfcBuilding _building)
        {
            using (XbimReadWriteTransaction txn = model.BeginTransaction("Create Building Story"))
            {
                var buildingStory = model.Instances.New<IfcBuildingStorey>();
                buildingStory.GlobalId = _buildingStory.GlobalId;
                buildingStory.Name = _buildingStory.Name;
                buildingStory.OwnerHistory.OwningUser = model.DefaultOwningUser;
                buildingStory.OwnerHistory.OwningApplication = model.DefaultOwningApplication;
                buildingStory.CompositionType = _buildingStory.CompositionType;
                buildingStory.ObjectPlacement = model.Instances.New<IfcLocalPlacement>();

                var localPlacement = buildingStory.ObjectPlacement as IfcLocalPlacement;
                var _localPlacement = _buildingStory.ObjectPlacement as IfcLocalPlacement;

                if (localPlacement != null && localPlacement.RelativePlacement == null)
                {

                    localPlacement.RelativePlacement = model.Instances.New<IfcAxis2Placement3D>();
                    //IfcAxis2Placement axis = _localPlacement.RelativePlacement;
                    var placement = localPlacement.RelativePlacement as IfcAxis2Placement3D;
                    var _placement = _localPlacement.RelativePlacement as IfcAxis2Placement3D;
                    //placement.Axis = _placement.Axis;
                    //placement.Location = _placement.Location;
                    //placement.RefDirection = _placement.RefDirection;
                    placement.SetNewLocation(_placement.Location.X, _placement.Location.Y, _placement.Location.Z);
                }

                // не проходит валидация 
                //buildingStory.SpatialStructuralElementParent.AddDecomposingObjectToFirstAggregation(model, _building);

                //buildingStory.ReferencesElements = _building;
                _building.AddElement(buildingStory);


                //if (model.Validate(txn.Modified(), Console.Out) == 0)
                //{
                    txn.Commit();
                    return buildingStory;
                //}

            }
            return null;
        }

        private void TestInsertModelToNew(XbimModel newmodel, XbimModel model)
        {
            var buildings = model.Instances.OfType<IfcBuilding>();
            var buildingStories = model.Instances.OfType<IfcBuildingStorey>();
            foreach (var building in buildings)
            {
                var _building = CopyBuilding(newmodel, building);
                foreach (var buildingStory in buildingStories)
                {
                    CopyBuildingStory(newmodel, buildingStory, _building);
                }
            }
            
            
        }

        private void ChangeModel(XbimModel model, XbimModel newmodel)
        {
            int i = 1;
            foreach (var o in model.Instances)
            {
                o.Bind(newmodel, i, true);
                i++;
            }
        }

        private XbimModel TestMergeModel(XbimModel newmodel, XbimModel firstmodel, XbimModel secondmodel)
        {
            int i = 1;
            foreach (var o in firstmodel.Instances)
            {
                o.Bind(newmodel, i, true);
                i++;
            }
            foreach (var o in secondmodel.Instances)
            {
                o.Bind(newmodel, i, true);
                i++;
            }
            return newmodel;
        }

        private void btnMerge_Click(object sender, RoutedEventArgs e)
        {
            if (IsTwoProject.IsChecked.Value)
            {
                // проверка на совпадения идентификаторов двух проектов
                // если они не совпадают то можно выполнять объединение 
                if (firsModel.IfcProject.GlobalId != secondModel.IfcProject.GlobalId && firsModel != null && secondModel != null)
                {
                    
                    var newmodel = CreateandInitModel("global_model");
                    if (newmodel != null)
                    {
                        // тестирование мержа
                        //TestMergeModel(newmodel, firsModel, secondModel);
                        // тестирование добавление объектов существующей модели в новую
                        TestInsertModelToNew(newmodel, firsModel);

                        List<IfcBuilding> listOfBuilding = new List<IfcBuilding>();
                        var listOfFirst = firsModel.IfcProducts.OfType<IfcBuilding>();

                            foreach (IfcBuilding b in listOfFirst)
                            {

                            }

                            foreach (IfcBuilding b2 in listOfBuilding)
                            {

                            
                            }

                            }
                        try
                        {
                            //Console.WriteLine("Standard Wall successfully created....");
                            //write the Ifc File
                            if (File.Exists("global_model.ifc"))
                                File.Delete("global_model.ifc");
                            newmodel.SaveAs("global_model.ifc", XbimStorageType.IFC);
                            //Console.WriteLine("HelloWall.ifc has been successfully written");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Failed to save global_model.ifc" + ex.Message);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Failed to initialise the model");
                    }
                }            
        }

        private void btnAddFile_Click(object sender, RoutedEventArgs e)
        {
            fileListBox.Items.Add(CreateOpenFileDialog());
        }

        private void btnTestAdd_Click(object sender, RoutedEventArgs e)
        {
            // тестирование добавление объекта стена в уже существующую модель
            TestAddInIFC(firsModel);
        }
    }
}
