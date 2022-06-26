namespace ExamenPrograJeancarlosBarberena.Models
{
    public class OrdenEstudiantes
    {
        public List<Estudiantes> Estudiante { get; set; }

        public static OrdenEstudiantes ListaEstudiantes = new OrdenEstudiantes();

        private OrdenEstudiantes()
        {
            Estudiante= new List<Estudiantes>();
            AgregarEstudiante("Cristiano Ronaldo Dos Santos Aveiro",37,"Terapía Física",815);

            AgregarEstudiante("Lionel Andrés Messi Cuccittini",35, "Terapía Física",672);


        }
        public void AgregarEstudiante(string nombre,int edad, string carrera,int cantCursos)
        {
            Estudiantes ES = new Estudiantes();
            ES.nombreCompletoEstudiante=nombre;
            ES.edadEstudiante = edad;
            ES.carreraEstudiante = carrera;
            ES.cursosEstudiante = cantCursos;
            ES.ID = 0;
            var est = Estudiante.OrderByDescending(x => x.ID).FirstOrDefault();
            ES.ID = est?.ID + 1 ?? 0;
            Estudiante.Add(ES);
        }
    }
}
    

