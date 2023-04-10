#region Menu
List<Persona> listaPersonas = new List<Persona>();
string resp;
do
{
    resp = Menu();

    string Menu()
    {
        Console.WriteLine("1. Cargar Nueva Persona");
        Console.WriteLine("2. Obtener Estadísticas del Censo");
        Console.WriteLine("3. Buscar Persona");
        Console.WriteLine("4. Modificar Mail de una Persona");
        Console.WriteLine("5. Salir");

        Console.Write("\nEliga la opcion que desea: ");
        return Console.ReadLine();
    }

    switch (resp)
    {

        case "1":
            CargarNuevaPersona();

            break;

        case "2":
            ObtenerEstadisticasDelCenso(listaPersonas);

            break;


        case "3":
            BuscarPersona();

            break;

        case "4":
            ModificarMailDeUnaPersona();

            break;
    }
} while (resp != "5");

#endregion

#region 1
void CargarNuevaPersona()
{


    Console.Write("Escriba el DNI de la persona: ");

    int dni = IngresarDNI();

    Console.Write("Escriba el nombre de la persona: ");

    string nom = IngresarCadena();

    Console.Write("Escriba el apellido de la persona: ");

    string ape = IngresarCadena();


    Console.Write("Escriba la fecha de nacimiento de la persona: ");

    DateTime fnac = IngresarFechaDeNacimiento();


    Console.Write("Escriba el email de la persona: ");

    string email = IngresarEmail();



    listaPersonas.Add(new Persona(dni, ape, nom, fnac, email));


}




int IngresarDNI()
{

    bool noValido = false;
    string respInicial;
    int dni;
    do
    {

        if (noValido) Console.Write("Ese DNI ya existe o el valor ingresado es incorrecto.\nVuelva a intentarlo: ");
        noValido = false;
        respInicial = Console.ReadLine();


        if (int.TryParse(respInicial, out dni) && (dni >= 10000000 && dni <= 99999999))
        {
            foreach (Persona p in listaPersonas)
            {

                if (p.DNI == dni)
                {
                    noValido = true;

                    break;
                }

            }
        }
        else
        {

            noValido = true;
        }
    } while (noValido);


    return dni;

}




string IngresarCadena()
{


    string cadena = Console.ReadLine();
    while (cadena == null)
    {

        Console.Write("Debe ingresar al menos un caracter.\nVuelva a intentarlo: ");
        cadena = Console.ReadLine();
    }

    return cadena;




}


DateTime IngresarFechaDeNacimiento()
{

    bool noValido = false;
    string respInicial;
    DateTime fnac;
    do
    {
        if (noValido) Console.Write("El valor ingresado es incorrecto.\nVuelva a intentarlo: ");
        noValido = false;

        respInicial = Console.ReadLine();


        noValido = !DateTime.TryParse(respInicial, out fnac) || fnac.Year > DateTime.Today.Year-1;

    } while (noValido);


    return fnac;


}

string IngresarEmail()
{
    bool noValido = false;
    string email;

    do
    {
        char caracter;
        int cantArroba = 0;
        if (noValido) Console.WriteLine("El valor ingresado es incorrecto.\nVuelva a intentarlo: ");
        noValido = false;
        email = Console.ReadLine();

        if (email.Any(caracter => caracter == '@')) cantArroba++;
        noValido = cantArroba != 1;


    } while (noValido);

    return email;

}


#endregion

#region 2
void ObtenerEstadisticasDelCenso(List<Persona> _lP)
{
    int cantPersonas = _lP.Count;

    if (cantPersonas == 0)
    {


        Console.WriteLine("\nAún no se ingresaron personas en la lista\n");

    }
    else
    {


        int cantPersonasVotar = 0;
        double promedioEdad, totalEdad = 0;

        for (int i = 0; i < _lP.Count; i++)
        {


            if (_lP[i].PuedeVotar()) cantPersonasVotar++;

            totalEdad += _lP[i].ObtenerEdad();

        }
        promedioEdad = totalEdad / cantPersonas;



        Console.WriteLine($"Estadísticas del Censo:\nCantidad de Personas: {cantPersonas}\nCantidad de Personas habilitadas para votar: {cantPersonasVotar}\nPromedio de Edad: {promedioEdad}");

    }


}
#endregion

#region 3
void BuscarPersona()
{
    Persona p = BuscarDni();
    if (p != null)
    {
        Console.WriteLine($"El nombre de la persona es {p.Nombre}\nEl apellido de la persona es {p.Apellido}\nLa fecha de nacimiento de la persona es {p.FechaNacimiento}\nLa edad de la persona es {p.ObtenerEdad()}");
        string puedeVotar = "";

        if (!p.PuedeVotar()) puedeVotar = "no ";

        Console.WriteLine($"La persona {puedeVotar}puede votar\nEl Email de la persona es {p.Email}");
    }

}


Persona BuscarDni()
{
    int rep = 0;
    int resp;
    if (listaPersonas.Count == 0)
    {
        Console.WriteLine("\n--Todavia no ha ingresado ninguna persona\n");
        return null;
    }


    while (true)
    {

        if (rep > 0) Console.WriteLine("No hay ninguna persona con ese DNI en el registro");
        rep++;

        Console.Write("Escribe el DNI de la persona que desea encontrar: ");

        resp = int.Parse(Console.ReadLine());

        foreach (Persona p in listaPersonas)
        {

            if (resp == p.DNI)
            {

                return p;
            }
        }

    }

}
#endregion

#region 4

void ModificarMailDeUnaPersona()
{

    Persona p = BuscarDni();
    if (p != null)
    {

        Console.Write("Escriba el nuevo Email de la persona: ");
        p.Email = IngresarEmail();

    }

}

#endregion

             ;
                ;
;;;;              ;
                  ;
                  ;
;;;;              ;
                ;
              ;