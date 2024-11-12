namespace SistemaEscolar
{
    public class PersonaModel
    {
        public int id { get; set; }
        public required string nombre { get; set; }
        public required string apellido {  get; set; }

        public required string sexo { get; set; }

        public DateTime fh_nac {  get; set; }

        public int id_rol {  get; set; }
    }
}