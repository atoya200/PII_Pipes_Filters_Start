using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ruta general de donde tener la imagen, para poder revisar si tiene cara o no
            // y para publicarlo
            string pathImage = "../../Imgs/ImagenModificada.jp";
            // Ejercicio 1
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"../../Imgs/luke.jpg");
            // Tuberías y filtros
            IPipe pipeNull = new PipeNull();
            IFilter filtroNegativo = new FilterNegative();
            IPipe pipeSerial2 = new PipeSerial(filtroNegativo, pipeNull);
            IFilter filtroGrises = new FilterGreyscale();
            IPipe pipeSerial1 = new PipeSerial(filtroGrises, pipeSerial2);
            // Ahora se realiza realmente la aplicación de filtros y demás. 
            IPicture newImage = pipeSerial1.Send(picture);
            provider.SavePicture(newImage, @"../../Imgs/NuevaImagen.jpg");

            //Ejercicio 2   
            IFilter filtroGuardar = new Filters.FilterSave();
            IPipe pipeSerial6 = new PipeSerial(filtroGuardar, pipeNull);
            IPipe pipeSerial5 = new PipeSerial(filtroNegativo, pipeSerial6);
            IPipe pipeSerial4 = new PipeSerial(filtroGuardar, pipeSerial5);
            IPipe pipeSerial3 = new PipeSerial(filtroGrises, pipeSerial4);
            // Ahora se realiza realmente la aplicación de filtros y demás. 
            IPicture picture2 = provider.GetPicture(@"../../Imgs/beer.jpg");
            pipeSerial3.Send(picture2);


            ///Ejercicio 3
            Filters.FilterTwitterAPI filtroPublicar = new Filters.FilterTwitterAPI(pathImage);
            IPipe pipeSerial12 = new PipeSerial(filtroPublicar, pipeNull);
            IPipe pipeSerial11 = new PipeSerial(filtroGuardar, pipeSerial12);
            IPipe pipeSerial10 = new PipeSerial(filtroNegativo, pipeSerial11);
            IPipe pipeSerial9 = new PipeSerial(filtroPublicar, pipeSerial10);
            IPipe pipeSerial8 = new PipeSerial(filtroGuardar, pipeSerial9);
            IPipe pipeSerial7 = new PipeSerial(filtroGrises, pipeSerial8);
            // Ahora se realiza realmente la aplicación de filtros y demás. 
            IPicture picture3 = provider.GetPicture(@"../../Imgs/HombreSonriente.jpg");
            pipeSerial7.Send(picture3);

            // Ejercicio 4
            // Caso en el que no hay un rostro
            IPicture picture4 = provider.GetPicture(@"../../Imgs/Leopardo.jpg");
            // Caso en el que si hay una cara
            IPicture picture5 = provider.GetPicture(@"../../Imgs/MujerSonriente.jpg");
            // Tuberías
            IPipe pipeSerial17 = new PipeSerial(filtroGuardar, pipeNull);
            IPipe pipeSerial16 = new PipeSerial(filtroNegativo, pipeSerial17);
            IPipe pipeSerial15 = new PipeSerial(filtroPublicar, pipeNull);
            IPipe pipeFork = new PipeForkConditional(pipeSerial15, pipeSerial16, pathImage);
            IPipe pipeSerial14 = new PipeSerial(filtroGuardar, pipeFork);
            IPipe pipeSerial13 = new PipeSerial(filtroGrises, pipeSerial14);

            // Caso en el que si hay una cara
            IPicture newImage3 = pipeSerial13.Send(picture5);
            // Caso en el que no hay un rostro
            IPicture newImage2 = pipeSerial13.Send(picture4);


        }
    }
}
