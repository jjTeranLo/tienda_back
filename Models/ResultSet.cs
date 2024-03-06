namespace BackEnd.Models
{
    public class ResultSet<Model>
    {
        public string Estatus { get; set; }
        public int CodigoEstatus { get; set; }
        public string Notificaciones { get; set; }
        public List<Model>? Data { get; set; }
        public Model? ObjData { get; set; }
    }
}