using System.Drawing;
using System;
using TwitterUCU;


namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la retorna en escala de grises.
    /// </remarks>
    public class FilterTwitterAPI : IFilter
    {


      
        /// <summary>
        /// Un filtro que retorna la imagen recibida con un filtro de escala de grises aplicado.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida pero en escala de grises.</returns>
        public IPicture Filter(IPicture image)
        {
            
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Mira mi nueva obra de arte crak", @$"../../Imgs/ImagenAPublicar.jpg"));
            return image;
        }
    }
}
