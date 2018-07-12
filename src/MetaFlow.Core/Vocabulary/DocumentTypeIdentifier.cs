//-------------------------------------------------------------------------------------------
// MetaFlow
// Author: Chris Moore, 0xCM@gmail.com
// License: MIT
//-------------------------------------------------------------------------------------------
namespace MetaFlow
{

    public class DocumentTypeIdentifier : ValueObject<DocumentTypeIdentifier>
    {
        public static implicit operator string(DocumentTypeIdentifier subject)
            => subject?.DocumentTypeName ?? string.Empty;

        public static implicit operator DocumentTypeIdentifier(string name)
            => new DocumentTypeIdentifier(name);

        public static readonly DocumentTypeIdentifier None
            = new DocumentTypeIdentifier("None");

        public string DocumentTypeName { get; }

        DocumentTypeIdentifier()
        {

        }

        public DocumentTypeIdentifier(string DocumentTypeName)
        {
            this.DocumentTypeName = DocumentTypeName;
        }

        public override string ToString()
            => DocumentTypeName;
    }
}
