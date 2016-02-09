using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestOpenIFC
{
    class TestClass
    {
    }


    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class students
    {

        private studentsStudent studentField;

        /// <remarks/>
        public studentsStudent student
        {
            get
            {
                return this.studentField;
            }
            set
            {
                this.studentField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class studentsStudent
    {

        private string nameField;

        private string batchField;

        private string schoolField;

        private studentsStudentMark[] marksField;

        /// <remarks/>
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        public string batch
        {
            get
            {
                return this.batchField;
            }
            set
            {
                this.batchField = value;
            }
        }

        /// <remarks/>
        public string school
        {
            get
            {
                return this.schoolField;
            }
            set
            {
                this.schoolField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("mark", IsNullable = false)]
        public studentsStudentMark[] marks
        {
            get
            {
                return this.marksField;
            }
            set
            {
                this.marksField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class studentsStudentMark
    {

        private string termField;

        private byte scienceField;

        private byte mathematicsField;

        private byte languageField;

        private string resultField;

        private studentsStudentMarkComments commentsField;

        /// <remarks/>
        public string term
        {
            get
            {
                return this.termField;
            }
            set
            {
                this.termField = value;
            }
        }

        /// <remarks/>
        public byte science
        {
            get
            {
                return this.scienceField;
            }
            set
            {
                this.scienceField = value;
            }
        }

        /// <remarks/>
        public byte mathematics
        {
            get
            {
                return this.mathematicsField;
            }
            set
            {
                this.mathematicsField = value;
            }
        }

        /// <remarks/>
        public byte language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        /// <remarks/>
        public string result
        {
            get
            {
                return this.resultField;
            }
            set
            {
                this.resultField = value;
            }
        }

        /// <remarks/>
        public studentsStudentMarkComments comments
        {
            get
            {
                return this.commentsField;
            }
            set
            {
                this.commentsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class studentsStudentMarkComments
    {

        private string teacherField;

        private string parentField;

        /// <remarks/>
        public string teacher
        {
            get
            {
                return this.teacherField;
            }
            set
            {
                this.teacherField = value;
            }
        }

        /// <remarks/>
        public string parent
        {
            get
            {
                return this.parentField;
            }
            set
            {
                this.parentField = value;
            }
        }
    }



    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class document
    {

        private documentDescriptions descriptionsField;

        private documentProperty[] propertiesField;

        private object sectionsField;

        private documentSpcDescriptions spcDescriptionsField;

        private byte modifiedField;

        /// <remarks/>
        public documentDescriptions descriptions
        {
            get
            {
                return this.descriptionsField;
            }
            set
            {
                this.descriptionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("property", IsNullable = false)]
        public documentProperty[] properties
        {
            get
            {
                return this.propertiesField;
            }
            set
            {
                this.propertiesField = value;
            }
        }

        /// <remarks/>
        public object sections
        {
            get
            {
                return this.sectionsField;
            }
            set
            {
                this.sectionsField = value;
            }
        }

        /// <remarks/>
        public documentSpcDescriptions spcDescriptions
        {
            get
            {
                return this.spcDescriptionsField;
            }
            set
            {
                this.spcDescriptionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte modified
        {
            get
            {
                return this.modifiedField;
            }
            set
            {
                this.modifiedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentDescriptions
    {

        private documentDescriptionsPropertyDescription[] propertyDescriptionsField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("propertyDescription", IsNullable = false)]
        public documentDescriptionsPropertyDescription[] propertyDescriptions
        {
            get
            {
                return this.propertyDescriptionsField;
            }
            set
            {
                this.propertyDescriptionsField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentDescriptionsPropertyDescription
    {

        private documentDescriptionsPropertyDescriptionValueVariant[] valueVariantField;

        private byte idField;

        private string nameField;

        private string typeValueField;

        private string natureIdField;

        private string unitIdField;

        private string commentField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("valueVariant")]
        public documentDescriptionsPropertyDescriptionValueVariant[] valueVariant
        {
            get
            {
                return this.valueVariantField;
            }
            set
            {
                this.valueVariantField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string typeValue
        {
            get
            {
                return this.typeValueField;
            }
            set
            {
                this.typeValueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string natureId
        {
            get
            {
                return this.natureIdField;
            }
            set
            {
                this.natureIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string unitId
        {
            get
            {
                return this.unitIdField;
            }
            set
            {
                this.unitIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string comment
        {
            get
            {
                return this.commentField;
            }
            set
            {
                this.commentField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentDescriptionsPropertyDescriptionValueVariant
    {

        private byte idField;

        private string valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentProperty
    {

        private byte idField;

        private string valueField;

        private byte modifiedField;

        private byte valueVariantIdField;

        private bool valueVariantIdFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte modified
        {
            get
            {
                return this.modifiedField;
            }
            set
            {
                this.modifiedField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte valueVariantId
        {
            get
            {
                return this.valueVariantIdField;
            }
            set
            {
                this.valueVariantIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool valueVariantIdSpecified
        {
            get
            {
                return this.valueVariantIdFieldSpecified;
            }
            set
            {
                this.valueVariantIdFieldSpecified = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptions
    {

        private documentSpcDescriptionsSpcDescription spcDescriptionField;

        /// <remarks/>
        public documentSpcDescriptionsSpcDescription spcDescription
        {
            get
            {
                return this.spcDescriptionField;
            }
            set
            {
                this.spcDescriptionField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescription
    {

        private documentSpcDescriptionsSpcDescriptionStyle styleField;

        private documentSpcDescriptionsSpcDescriptionDocuments documentsField;

        private documentSpcDescriptionsSpcDescriptionObject[] spcObjectsField;

        private documentSpcDescriptionsSpcDescriptionObject2[] spcCommentObjectsField;

        private documentSpcDescriptionsSpcDescriptionSection[] spcStructField;

        /// <remarks/>
        public documentSpcDescriptionsSpcDescriptionStyle style
        {
            get
            {
                return this.styleField;
            }
            set
            {
                this.styleField = value;
            }
        }

        /// <remarks/>
        public documentSpcDescriptionsSpcDescriptionDocuments documents
        {
            get
            {
                return this.documentsField;
            }
            set
            {
                this.documentsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("object", IsNullable = false)]
        public documentSpcDescriptionsSpcDescriptionObject[] spcObjects
        {
            get
            {
                return this.spcObjectsField;
            }
            set
            {
                this.spcObjectsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("object", IsNullable = false)]
        public documentSpcDescriptionsSpcDescriptionObject2[] spcCommentObjects
        {
            get
            {
                return this.spcCommentObjectsField;
            }
            set
            {
                this.spcCommentObjectsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("section", IsNullable = false)]
        public documentSpcDescriptionsSpcDescriptionSection[] spcStruct
        {
            get
            {
                return this.spcStructField;
            }
            set
            {
                this.spcStructField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionStyle
    {

        private documentSpcDescriptionsSpcDescriptionStyleSection[] sectionsField;

        private documentSpcDescriptionsSpcDescriptionStyleBlock[] additionalBlocksField;

        private documentSpcDescriptionsSpcDescriptionStyleColumn[] columnsField;

        private documentSpcDescriptionsSpcDescriptionStyleColumn1[] additionalColumnsField;

        private string fileNameField;

        private decimal idField;

        private string massUnitField;

        private byte massCommaSizeField;

        private byte modifiedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("section", IsNullable = false)]
        public documentSpcDescriptionsSpcDescriptionStyleSection[] sections
        {
            get
            {
                return this.sectionsField;
            }
            set
            {
                this.sectionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("block", IsNullable = false)]
        public documentSpcDescriptionsSpcDescriptionStyleBlock[] additionalBlocks
        {
            get
            {
                return this.additionalBlocksField;
            }
            set
            {
                this.additionalBlocksField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("column", IsNullable = false)]
        public documentSpcDescriptionsSpcDescriptionStyleColumn[] columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("column", IsNullable = false)]
        public documentSpcDescriptionsSpcDescriptionStyleColumn1[] additionalColumns
        {
            get
            {
                return this.additionalColumnsField;
            }
            set
            {
                this.additionalColumnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string fileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string massUnit
        {
            get
            {
                return this.massUnitField;
            }
            set
            {
                this.massUnitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte massCommaSize
        {
            get
            {
                return this.massCommaSizeField;
            }
            set
            {
                this.massCommaSizeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte modified
        {
            get
            {
                return this.modifiedField;
            }
            set
            {
                this.modifiedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionStyleSection
    {

        private documentSpcDescriptionsSpcDescriptionStyleSectionBlock[] nestingBlocksField;

        private string nameField;

        private byte numberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("block", IsNullable = false)]
        public documentSpcDescriptionsSpcDescriptionStyleSectionBlock[] nestingBlocks
        {
            get
            {
                return this.nestingBlocksField;
            }
            set
            {
                this.nestingBlocksField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionStyleSectionBlock
    {

        private documentSpcDescriptionsSpcDescriptionStyleSectionBlockSection[] sectionsField;

        private string nameField;

        private byte numberField;

        private byte includedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("section", IsNullable = false)]
        public documentSpcDescriptionsSpcDescriptionStyleSectionBlockSection[] sections
        {
            get
            {
                return this.sectionsField;
            }
            set
            {
                this.sectionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte included
        {
            get
            {
                return this.includedField;
            }
            set
            {
                this.includedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionStyleSectionBlockSection
    {

        private byte numberField;

        private byte includedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte included
        {
            get
            {
                return this.includedField;
            }
            set
            {
                this.includedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionStyleBlock
    {

        private documentSpcDescriptionsSpcDescriptionStyleBlockSection[] sectionsField;

        private string nameField;

        private byte numberField;

        private byte includedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("section", IsNullable = false)]
        public documentSpcDescriptionsSpcDescriptionStyleBlockSection[] sections
        {
            get
            {
                return this.sectionsField;
            }
            set
            {
                this.sectionsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte included
        {
            get
            {
                return this.includedField;
            }
            set
            {
                this.includedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionStyleBlockSection
    {

        private byte numberField;

        private byte includedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte included
        {
            get
            {
                return this.includedField;
            }
            set
            {
                this.includedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionStyleColumn
    {

        private string nameField;

        private string typeNameField;

        private byte typeField;

        private byte numberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string typeName
        {
            get
            {
                return this.typeNameField;
            }
            set
            {
                this.typeNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionStyleColumn1
    {

        private string nameField;

        private string typeNameField;

        private byte typeField;

        private byte numberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string typeName
        {
            get
            {
                return this.typeNameField;
            }
            set
            {
                this.typeNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionDocuments
    {

        private documentSpcDescriptionsSpcDescriptionDocumentsDocument documentField;

        /// <remarks/>
        public documentSpcDescriptionsSpcDescriptionDocumentsDocument document
        {
            get
            {
                return this.documentField;
            }
            set
            {
                this.documentField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionDocumentsDocument
    {

        private string fileNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string fileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionObject
    {

        private documentSpcDescriptionsSpcDescriptionObjectSection sectionField;

        private documentSpcDescriptionsSpcDescriptionObjectColumn[] columnsField;

        private documentSpcDescriptionsSpcDescriptionObjectAdditionalColumns additionalColumnsField;

        private decimal idField;

        private byte modifiedField;

        /// <remarks/>
        public documentSpcDescriptionsSpcDescriptionObjectSection section
        {
            get
            {
                return this.sectionField;
            }
            set
            {
                this.sectionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("column", IsNullable = false)]
        public documentSpcDescriptionsSpcDescriptionObjectColumn[] columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        /// <remarks/>
        public documentSpcDescriptionsSpcDescriptionObjectAdditionalColumns additionalColumns
        {
            get
            {
                return this.additionalColumnsField;
            }
            set
            {
                this.additionalColumnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte modified
        {
            get
            {
                return this.modifiedField;
            }
            set
            {
                this.modifiedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionObjectSection
    {

        private byte numberField;

        private byte subSecNumberField;

        private byte additionalBlockNumberField;

        private byte additionalSecNumberField;

        private byte nestingBlockNumberField;

        private byte nestingSecNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte subSecNumber
        {
            get
            {
                return this.subSecNumberField;
            }
            set
            {
                this.subSecNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte additionalBlockNumber
        {
            get
            {
                return this.additionalBlockNumberField;
            }
            set
            {
                this.additionalBlockNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte additionalSecNumber
        {
            get
            {
                return this.additionalSecNumberField;
            }
            set
            {
                this.additionalSecNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte nestingBlockNumber
        {
            get
            {
                return this.nestingBlockNumberField;
            }
            set
            {
                this.nestingBlockNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte nestingSecNumber
        {
            get
            {
                return this.nestingSecNumberField;
            }
            set
            {
                this.nestingSecNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionObjectColumn
    {

        private string nameField;

        private string typeNameField;

        private byte typeField;

        private byte numberField;

        private byte blockNumberField;

        private string valueField;

        private byte modifiedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string typeName
        {
            get
            {
                return this.typeNameField;
            }
            set
            {
                this.typeNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte blockNumber
        {
            get
            {
                return this.blockNumberField;
            }
            set
            {
                this.blockNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte modified
        {
            get
            {
                return this.modifiedField;
            }
            set
            {
                this.modifiedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionObjectAdditionalColumns
    {

        private documentSpcDescriptionsSpcDescriptionObjectAdditionalColumnsColumn columnField;

        /// <remarks/>
        public documentSpcDescriptionsSpcDescriptionObjectAdditionalColumnsColumn column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionObjectAdditionalColumnsColumn
    {

        private string nameField;

        private string typeNameField;

        private byte typeField;

        private byte numberField;

        private byte blockNumberField;

        private string valueField;

        private byte modifiedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string typeName
        {
            get
            {
                return this.typeNameField;
            }
            set
            {
                this.typeNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte blockNumber
        {
            get
            {
                return this.blockNumberField;
            }
            set
            {
                this.blockNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte modified
        {
            get
            {
                return this.modifiedField;
            }
            set
            {
                this.modifiedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionObject2
    {

        private documentSpcDescriptionsSpcDescriptionObjectSection1 sectionField;

        private documentSpcDescriptionsSpcDescriptionObjectColumns columnsField;

        private decimal idField;

        private byte modifiedField;

        /// <remarks/>
        public documentSpcDescriptionsSpcDescriptionObjectSection1 section
        {
            get
            {
                return this.sectionField;
            }
            set
            {
                this.sectionField = value;
            }
        }

        /// <remarks/>
        public documentSpcDescriptionsSpcDescriptionObjectColumns columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte modified
        {
            get
            {
                return this.modifiedField;
            }
            set
            {
                this.modifiedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionObjectSection1
    {

        private byte numberField;

        private byte subSecNumberField;

        private byte additionalBlockNumberField;

        private byte additionalSecNumberField;

        private byte nestingBlockNumberField;

        private byte nestingSecNumberField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte subSecNumber
        {
            get
            {
                return this.subSecNumberField;
            }
            set
            {
                this.subSecNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte additionalBlockNumber
        {
            get
            {
                return this.additionalBlockNumberField;
            }
            set
            {
                this.additionalBlockNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte additionalSecNumber
        {
            get
            {
                return this.additionalSecNumberField;
            }
            set
            {
                this.additionalSecNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte nestingBlockNumber
        {
            get
            {
                return this.nestingBlockNumberField;
            }
            set
            {
                this.nestingBlockNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte nestingSecNumber
        {
            get
            {
                return this.nestingSecNumberField;
            }
            set
            {
                this.nestingSecNumberField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionObjectColumns
    {

        private documentSpcDescriptionsSpcDescriptionObjectColumnsColumn columnField;

        /// <remarks/>
        public documentSpcDescriptionsSpcDescriptionObjectColumnsColumn column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionObjectColumnsColumn
    {

        private string nameField;

        private string typeNameField;

        private byte typeField;

        private byte numberField;

        private byte blockNumberField;

        private string valueField;

        private byte modifiedField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string typeName
        {
            get
            {
                return this.typeNameField;
            }
            set
            {
                this.typeNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte blockNumber
        {
            get
            {
                return this.blockNumberField;
            }
            set
            {
                this.blockNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte modified
        {
            get
            {
                return this.modifiedField;
            }
            set
            {
                this.modifiedField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionSection
    {

        private documentSpcDescriptionsSpcDescriptionSectionObject[] objectField;

        private string textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("object")]
        public documentSpcDescriptionsSpcDescriptionSectionObject[] @object
        {
            get
            {
                return this.objectField;
            }
            set
            {
                this.objectField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class documentSpcDescriptionsSpcDescriptionSectionObject
    {

        private decimal idField;

        private string textField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
    }


}
