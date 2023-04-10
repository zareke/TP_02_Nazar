class Persona{

public Persona(int _dni, string _ape, string _nom, DateTime _fnac, string _email){

DNI = _dni;

Apellido = _ape;

Nombre = _nom;

FechaNacimiento = _fnac;

Email = _email;

}
public int DNI{get;set;}

string Apellido{get;set;}
string  Nombre{get;set;}

string Email{get;set;}

DateTime FechaNacimiento{get;set;}


public bool PuedeVotar(){

      return ObtenerEdad() >=16;
}


public int ObtenerEdad(){

DateTime hoy = DateTime.Today;
    int edad;
    edad = hoy.Year - FechaNacimiento.Year;

    if (hoy.Month < FechaNacimiento.Month || (hoy.Month == FechaNacimiento.Month && hoy.Day < FechaNacimiento.Day))
        edad--;


  return edad;

}



}