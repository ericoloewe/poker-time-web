namespace App.Helpers
{
    public static class CriptoHelper
    {
        public static string encrypt(string chiper)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(chiper);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);

            return System.Text.Encoding.ASCII.GetString(data);
        }
    }
}