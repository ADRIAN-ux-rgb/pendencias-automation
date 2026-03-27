using System;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.VisualBasic;
using System.Data.Common;

class Program
{
    static async Task Main(string[] args)
    {
        while (true)
        {
            try
            {

               



                Console.WriteLine($"Iniciando verificação: {DateTime.Now}");

                await ExecutarRotinaAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro na rotina: {ex.Message}");
            }



            Console.WriteLine("Aguardando 10 SEGUNDOS");
            await Task.Delay(TimeSpan.FromSeconds(10));
        }
   }

  


   static async Task ExecutarRotinaAsync()
    {
        Console.WriteLine("Executando rotina...");
        await Task.CompletedTask;

      var pendencias = BuscarPendencias();

       
      Console.WriteLine($"Quantidade de pendencias: {pendencias.Count}");

      foreach (var p in pendencias) 
   {
    Console.WriteLine($"ExternalId: {p.ExternalId}");
    Console.WriteLine($"PayerNumber: {p.PayerNumber}");
   }
    }

   static List<Pendencia> BuscarPendencias()
 {
    var lista = new List<Pendencia>();
  
  
    string connectionString =  "Server=localhost,1433;Database=AutomacaoPendencias;User Id=sa;Password=SuaSenhaForte123!;TrustServerCertificate=True;";
    string query =  "SELECT ExternalId, PayerNumber FROM Pendencias WHERE Status = 'PENDENTE'";

     using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();

            using SqlCommand command =  new SqlCommand(query, conn);   
        }
         
    return lista;
 }
 
    



}