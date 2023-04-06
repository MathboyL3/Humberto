using Atividades;
using Sorting;

IAtividade[] atividades =
{
    new Atividade1(),
    new Atividade2(),
    new Atividade3(),
    new Atividade4(),
};

foreach(IAtividade atividade in atividades)
{
    atividade.Executar();
    Console.ReadKey(true);
    Console.WriteLine();
}