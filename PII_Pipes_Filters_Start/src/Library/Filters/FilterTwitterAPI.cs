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
        protected string pathImage {get; set;}

        public FilterTwitterAPI(string pathName)
        {
            this.pathImage = pathName;
        }
        /// <summary>
        /// Un filtro que retorna la imagen recibida con un filtro de escala de grises aplicado.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida pero en escala de grises.</returns>
        public IPicture Filter(IPicture image)
        {
            IPicture result = image;
            var twitter = new TwitterImage();
            Console.WriteLine(twitter.PublishToTwitter("Foto nueva", @$"{this.pathImage}"));

            return result;
        }
    }
}
