using System;
using System.Drawing;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y retorna su negativo.
    /// </remarks>
    public class FilterSave : IFilter
    {
        /// <summary>
        /// Para saber bien en que paso de cambiar esa p
        /// </summary>
        /// <value></value>
        public int NumUltimatePhoto { get; private set; }

        private string namePhoto;
        /// <summary>
        ///  Nombre de la foto a la que se le aplican los filtros y se va a guardar
        /// </summary>
        /// <value>Nombre que se le de a la foto, ejemplo "beer"</value>
        public string NamePhoto
        {
            get
            {
                return this.namePhoto;
            }
            set
            {
                if (this.namePhoto != value)
                {
                    this.NumUltimatePhoto = 0;
                    this.namePhoto = value;
                }
            }
        }


        /// Un filtro que retorna el negativo de la imagen recibida.
        /// </summary>
        /// <param name="image">La imagen a la cual se le va a aplicar el filtro.</param>
        /// <returns>La imagen recibida solo se guarda, y se retorna sin aplicarle ningún cambio.</returns>
        public IPicture Filter(IPicture image)
        {
            this.NumUltimatePhoto += 1;
            PictureProvider provider = new PictureProvider();
            // Guardamos la imagen con un distintivo a la del paso anterior, a la del filtro anterior
            provider.SavePicture(image, @$"../../Imgs/{this.NamePhoto} paso {this.NumUltimatePhoto}.jpg");
            // Para que el filtro de publicar la foto sepa bien que foto poner, creamos una imagen que se va a 
            // sobreescribir con cada llamado de guarda, la cual tendría la transformación más reciente antes de 
            // usar el publicar, así como antes de aplicarle el filtro condicional
            provider.SavePicture(image, @$"../../Imgs/ImagenAPublicar.jpg");
            return image;
        }
    }
}
