using bookDemo.Models;
namespace bookDemo.Data
{
    public static class ApplicationContext //static yaparak bellekte bu alana bir veri koyacağız ve bu alana her kim ulaşırsa ulaşsın buradaki değişiklikleri doğrudan gözlemlemiş olacak.
    {
        public static List<Book> Books { get; set; }
        //static bir nesnenin mümkün olmadığından constructor ifadesinde public yerine static kullanılmalı.
        static ApplicationContext()
        {
            Books=new List<Book>()
            { 
                new Book(){ID=1, Title="Karagöz ve Hacivat", Price=75},
                new Book(){ID=2,Title="Mesnevi", Price=150},
                new Book(){ID=3,Title="Dede Korkut",Price=75}
            };
        }
    }
}