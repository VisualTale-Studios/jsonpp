namespace jsonpp
{
    class NameReference
    {
        public NameReference() { }

        public NameReference(string alisa, string name) { Alisa = alisa; Literal = name; }

        public string Alisa { get; set; }

        public string Literal { get; set; }

        public int Times { get; set; }
    }
}
