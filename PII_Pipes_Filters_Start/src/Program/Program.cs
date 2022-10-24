using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;

namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ejercicio 1
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"../../Imgs/luke.jpg");
            // Tuberías y filtros
            PipeNull pipeNull = new PipeNull();
            Filters.FilterNegative  filtroNegativo = new Filters.FilterNegative();
            PipeSerial pipeSerial2 = new PipeSerial(filtroNegativo, pipeNull);
            Filters.FilterGreyscale  filtroGrises = new Filters.FilterGreyscale();
            PipeSerial pipeSerial1 = new PipeSerial(filtroGrises, pipeSerial2);
            // Ahora se realiza realmente la aplicación de filtros y demás. 
            IPicture newImage = pipeSerial1.Send(picture);
            provider.SavePicture(newImage, @"../../Imgs/NuevaImagen.jpg"); 

            //Ejercicio 2   
            Filters.FilterSave filtroGuardar = new Filters.FilterSave();
            PipeSerial pipeSerial6 = new PipeSerial(filtroGuardar, pipeNull);
            PipeSerial pipeSerial5 = new PipeSerial(filtroNegativo, pipeSerial6);
            PipeSerial pipeSerial4 = new PipeSerial(filtroGuardar, pipeSerial5);
            PipeSerial pipeSerial3 = new PipeSerial(filtroGrises, pipeSerial4 );
            // Ahora se realiza realmente la aplicación de filtros y demás. 
            IPicture picture2 = provider.GetPicture(@"../../Imgs/beer.jpg");
            picture2.Name = "Beer";
            pipeSerial3.Send(picture2); 

            
            ///Ejercicio 3
            Filters.FilterPublished filtroPublicar = new Filters.FilterPublished();
            PipeSerial pipeSerial12 = new PipeSerial(filtroPublicar, pipeNull);
            PipeSerial pipeSerial11= new PipeSerial(filtroGuardar, pipeSerial12);
            PipeSerial pipeSerial10 = new PipeSerial(filtroNegativo, pipeSerial11);
            PipeSerial pipeSerial9 = new PipeSerial(filtroPublicar, pipeSerial10 );
            PipeSerial pipeSerial8 = new PipeSerial(filtroGuardar, pipeSerial9 );
            PipeSerial pipeSerial7 = new PipeSerial(filtroGrises, pipeSerial8 );
            // Ahora se realiza realmente la aplicación de filtros y demás. 
            IPicture picture3 = provider.GetPicture(@"../../Imgs/HombreSonriente.jpg");
            picture3.Name = "HombreSonriente";
            pipeSerial7.Send(picture3); 

            // Ejercicio 4
            // Caso en el que no hay un rostro
            IPicture picture4 = provider.GetPicture(@"../../Imgs/Leopardo.jpg");
            picture4.Name = "Leopardo";
            // Caso en el que si hay una cara
            IPicture picture5 = provider.GetPicture(@"../../Imgs/MujerSonriente.jpg");
            picture5.Name = "Doña";
            // Tuberías
            PipeSerial pipeSerial17 = new PipeSerial(filtroGuardar, pipeNull);
            PipeSerial pipeSerial16 = new PipeSerial(filtroNegativo, pipeSerial17);
            PipeSerial pipeSerial15 = new PipeSerial(filtroPublicar, pipeNull);
            PipeFork pipeFork = new PipeFork(pipeSerial15, pipeSerial16);
            PipeSerial pipeSerial14 = new PipeSerial(filtroGuardar, pipeFork);
            PipeSerial pipeSerial13 = new PipeSerial(filtroGrises, pipeSerial14);
            
            // Caso en el que si hay una cara
            IPicture newImage3 = pipeSerial13.Send(picture5);
            provider.SavePicture(newImage3, @$"{newImage3.PathImage}");
            // Caso en el que no hay un rostro
            IPicture newImage2 = pipeSerial13.Send(picture4);
            provider.SavePicture(newImage2, @$"{newImage2.PathImage}");
            
            
        }
    }
}
