namespace Core_Project.Areas.Document.Models
{
    public class AddDocumentsViewModel
    {
        public string? CourseName { get; set; }
        public string? Title { get; set; }
        public IFormFile? PdfFile { get; set; } // PDF dosyasını yüklemek için

    }
}
