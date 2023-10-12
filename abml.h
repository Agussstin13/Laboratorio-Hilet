#include<iostream>
#include<fstream>
#include<stdlib.h>
#include<string>
#include <cstdio>

using namespace std;
/*
class Clientes{
	private:
		string Nombre;
		string Apellido;
		string Mascota;
		string Texto;
	public:
		void Alta(){
			fstream archivo("Clientes.txt", ios::app);
			cout<<"El nombre del cliente: ";
			cin>>Nombre;
			cout<<"El apellido del cliente: ";
			cin>>Apellido;
			cout<<"El nombre de la mascota: ";
			cin>>Mascota;
			archivo<<Nombre<<" "<<Apellido<<" "<<Mascota;
			system("pause");
			system("cls");
		}
		void Listar(){
			ifstream Leer("Clientes.txt");
			if(!Leer.is_open()){
				cout<<"No se ha encontrado el archivo";
				system("cls");	
			}else{
				string Texto;
				getline(Leer, Texto);
				cout<<Texto;
			}
		}
		
		void Borrar(){
			ifstream Leer("Clientes.txt");
			cout<<"Ingrese el nombre del cliente: ";
			cin>>Nombre;
			getline(Leer, Texto);
			cout<<Texto.find(Nombre);
			cout<<"Ingrese el apellido: ";
			cin>>Apellido;
			
			
		}
		
		Clientes(int op){
			ifstream leer("Clientes.txt");
			if(!leer.is_open()){
				cout<<"No ha encontrado el documento Clientes.txt"<<endl<<"Se Creara uno nuevo";
				ofstream arch("Turnos.txt");
				arch.close();
			}
			switch (op){
				case 1: Alta(); break;
				case 4: Listar(); break;			
			}	
		}
		
};


class Turnos{
	private:
		string fecha;
	public:
		void Listar(){
			ifstream archivo("Turnos.txt");
			string texto;
			getline(archivo, texto);
			cout<<texto;
			system("pause");
			system("cls");
		}
		void Alta(){
				fstream archivo("Turnos.txt", ios::app);
				cout<<"Ingrese la fecha del turno: ";
				cin>>fecha;
				cout<<fecha;
				archivo<<fecha;
				system("pause");
				system("cls");		
		}
		Turnos(int op){
			ifstream leer("Turnos.txt");
			if(!leer.is_open()){
				cout<<"No ha encontrado el documento Turnos.txt"<<endl<<"Se Creara uno nuevo";
				ofstream arch("Turnos.txt");
				arch.close();
			}
			switch (op){
				case 1: Alta(); break;
				case 4: Listar(); break;			
			}			
			//vos podes!
		} //mi amor te amo mucho		
};
*/



void Empleados(int op){
	string nombre, apellido, DNI, texto;
	ifstream Leer("Empleados.txt");
	if (!Leer.is_open()) {
		cout<<"No se encontro el archivo Empleados.txt, se creara uno nuevo..."<<endl;
		system("pause");
		ofstream Escribir("Empleados.txt");
		Escribir.close();
		Leer.open("Empleados.txt", ios::in);
	}
	Leer.seekg(0, ios::end);
    streampos fileSize = Leer.tellg();
    Leer.seekg(0, ios::beg);
	switch (op){
		case 1:{//Alta
		ofstream Escribir("Empleados.txt", ios::out | ios::app);
			if(fileSize == 0){
				cout<<"Ingrese el nombre del empleados: ";
				cin>>nombre;
				cout<<"Ingrese el apellido del empleados: ";
				cin>>apellido;
				cout<<"Ingrese el DNI del empleados: ";
				cin>>DNI;
				Escribir<<nombre<<" "<<apellido<<" "<<DNI;
				cout<<"El nuevo empleado se cargo correctamente"<<endl;
				system("pause");
				system("cls");
				break;
			}else{
				cout<<"Ingrese el nombre del empleados: ";
				cin>>nombre;
				cout<<"Ingrese el apellido del empleados: ";
				cin>>apellido;
				cout<<"Ingrese el DNI del empleados: ";
				cin>>DNI;
				Escribir<<"\n"<<nombre<<" "<<apellido<<" "<<DNI;
				cout<<"El nuevo empleado se cargo correctamente"<<endl;
				system("pause");
				system("cls");
				break;				
			}

		}
		case 2:{//Baja
			do{	
				char charop;
				int intop;
				int i=0; 
    			
				if(fileSize == 0){
					cout<<"Aun no se han cargado registros"<<endl;
					system("pause");
					system("cls");
					break;
				}
				while (!Leer.eof()) {
					i++;
					cout<<i<<"."; Leer>>nombre; cout<<nombre;
					Leer>>apellido; cout<<" "<<apellido;
					Leer>>DNI; cout<<" "<<DNI<<endl;
				}
				// hasta aca se lista el contenido del archivo
				
				cout<<"Ingrese el id de empleado a eliminar: ";
				cin>>charop;
				
				Leer.close();
				if (isdigit(charop)) {
					intop = charop - '0'; // si es un numero lo convierte a entero
					ofstream aux("auxi.txt");
					if (!aux.is_open()) {
						cout<<"Ha ocurrido un problema al intentar borrar un archivo..."<<endl;
						system("pause");
						break;
					}
					for (int c=1;c<=i;c++) {
						Leer>>nombre;
						Leer>>apellido;
						Leer>>DNI;
						if (c!=intop) {							
							aux << nombre << " " << apellido << " " << DNI << endl;
						}
					}
					aux.close();
					ofstream Empleados("Empleados.txt");
					ifstream Leeraux("auxi.txt");
					for (int c=1;c<i;c++) {
						Leeraux>>nombre;
						Leeraux>>apellido;
						Leeraux>>DNI;
						Empleados<<nombre<<" "<<apellido<<" "<<DNI<<endl;
					}
					remove("auxi.txt");
				}else{
					cout<<"\nNo se ingreso un valor valido"<<endl;
				}
				system("pause");
				system("cls");					
				break;				
			}while(true);

		}
		default: break;
	}
}

void MenuABML(int op){
	char op2;
	int num;
	do{
		switch (op){
			case 1: cout<<"              Turnos";break;
			case 2: cout<<"              Clientes";break;
			case 3: cout<<"              Empleados";break;
			default: exit(0);
		}
		cout<<"\n1.Alta"<<endl;
		cout<<"2.Baja"<<endl;
		cout<<"3.Modificar"<<endl;
		cout<<"4.Listar"<<endl;
		cout<<"4.Atras"<<endl;
		cout<<"Opcion: ";
		cin>>op2;
		system("cls");
		if(!isdigit(op2)){		
			cout<<"No se ingreso un valor valido"<<endl;
			system("pause");
			system("cls");
		}else{
			num = op2 - '0';
			switch(op){
				case 1: //Turnos(num);
				case 2: //ABML("Clientes.txt", num);
				case 3: Empleados(num);
				default: break; break;
			}
		}
	}while(false);	
}


