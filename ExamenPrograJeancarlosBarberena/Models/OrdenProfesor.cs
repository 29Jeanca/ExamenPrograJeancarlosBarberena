namespace ExamenPrograJeancarlosBarberena.Models
{
    public class OrdenProfesor
    {
        public List<Profesores> Profesor { get; set; }

        public static OrdenProfesor ListaProfesor=new OrdenProfesor();
        
        private OrdenProfesor()
        {
            Profesor = new List<Profesores>();
            AgregarProfesor("Ricardo Monge Gapper","cédula: ",5060123, "Informática");
            AgregarProfesor("Luis Diego Fonseca Vargas", "cédula: ", 111111, "Matemáticas");
            

        }
        public void AgregarProfesor(string nombreProfesor,string nc,int cedula, string conocimiento)
        {
            Profesores pr = new Profesores();

            pr.nombreCompletoProfesor = nombreProfesor;
            pr.cedulaProfesor = cedula;
            pr.areaConocimiento = conocimiento;
            pr.ID = 0;
            var prc = Profesor.OrderByDescending(x => x.ID).FirstOrDefault();
            pr.ID = prc?.ID + 1 ?? 0;
            Profesor.Add(pr);
        }
    }
}
