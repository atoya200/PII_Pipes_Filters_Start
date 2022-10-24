using System;
using System.Drawing;
using CompAndDel;

namespace CompAndDel.Filters
{
    /// <summary>
    /// Un filtro de convolución que retorna la imagen recibida con los bordes suavizados. Basado en
    /// https://en.wikipedia.org/wiki/Box_blur utilizando el kernel
    /// https://wikimedia.org/api/rest_v1/media/math/render/svg/91256bfeece3344f8602e288d445e6422c8b8a1c.
    /// </summary>
    public  class FilterBlurConvolution : FilterConvolution
    {
        /// <summary>
        /// Inicializa una nueva instancia de <c>FilterBlurConvolution</c> asignando el kernel, complemento, y divisor
        /// según https://wikimedia.org/api/rest_v1/media/math/render/svg/91256bfeece3344f8602e288d445e6422c8b8a1c.
        /// </summary>
        public FilterBlurConvolution()
        {
            this.kernel = new int[3, 3];
            this.complement = 0;
            this.divider = 9;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    kernel[x, y] = 1;
                }
            }
        }
        
        

    }
}