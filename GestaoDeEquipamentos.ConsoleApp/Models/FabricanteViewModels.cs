using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;

namespace GestaoDeEquipamentos.ConsoleApp.Models
{
    public class CadastrarFabricanteViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public CadastrarFabricanteViewModel() { }

        public CadastrarFabricanteViewModel(string nome, string email, string telefone) : this()
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }

    public class EditarFabricanteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public EditarFabricanteViewModel(int id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
    }

    public class ExcluirFabricanteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ExcluirFabricanteViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class VisualizarFabricantesViewModel
    {
        public List<DetalhesFabricantesViewModel> Registros { get; } = new List<DetalhesFabricantesViewModel>();


        public VisualizarFabricantesViewModel(List<Fabricante> fabricantes)
        {
            foreach (Fabricante f in fabricantes)
            {
                DetalhesFabricantesViewModel detalhesVM = new DetalhesFabricantesViewModel(
                    f.Id,
                    f.Nome,
                    f.Email,
                    f.Telefone);

                Registros.Add(detalhesVM);
            }

        }
    }

    public class DetalhesFabricantesViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public DetalhesFabricantesViewModel(int id, string nome, string email, string telefone)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }
        public override string ToString()
        {
            return $"Id: {Id}, Nome: {Nome}, Email: {Email}, Telefone: {Telefone}";
        }
    }


    
}
