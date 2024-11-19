namespace Scooterland.Server.DataAccess
{
	public class ConnectionHandler
	{
		//public string GetConnectionStringSQLClient()
		//{
		//	return ConfigurationManager.ConnectionStrings["Frederik"].ToString();
		//}
		public static string GetConnectionStringEF()
		{
			return "Server=FREDERIK;Database=ScooterlandDb;Trusted_Connection=True;TrustServerCertificate=True;";
		}
	}
}
