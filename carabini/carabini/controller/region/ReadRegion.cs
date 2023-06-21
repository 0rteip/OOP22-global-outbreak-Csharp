namespace region
{
    public class  ReadRegion
    {
    #pragma warning disable CS8618 // Il campo non nullable deve contenere un valore non Null all'uscita dal costruttore. Provare a dichiararlo come nullable.
        public string Nome { get; set; }
    #pragma warning restore CS8618 // Il campo non nullable deve contenere un valore non Null all'uscita dal costruttore. Provare a dichiararlo come nullable.
        public int Colore { get; set; }
        public int Porti { get; set; }
        public int Aereoporti { get; set; }

        public List<string>? Confini { get; set; }

        public float Humid { get; set; }
        public float Hot { get; set; }
        public long PopTot { get; set; }
        public int Facilities { get; set; }
        public float Poor { get; set; }
        public float Urban { get; set; }
        public float CloseMeans { get; set; }
    }
}
