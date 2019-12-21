using  System.ComponentModel.DataAnnotations;
namespace Appsx.Models {
public class Contato {


    public int Id {set; get;}
    
    [Required,StringLength(20)]    
    public string Nome {set; get;}
}
}