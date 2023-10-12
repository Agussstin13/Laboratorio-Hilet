#include<iostream>
#include<fstream>
#include<stdlib.h>
#include<abml.h>

using namespace std;

void Menu(){
	char op1;
	int num;
	do{
		cout<<"              MCR Veterinaria"<<endl;
		cout<<"1.Gestion de turnos"<<endl;
		cout<<"2.Actualizar Clientes"<<endl;
		cout<<"3.Actualizar Empleados"<<endl;
		cout<<"4.Salir"<<endl;
		cout<<"Opcion: ";
		cin>>op1;
		system("cls");
		if(!isdigit(op1)){		
			cout<<"No se ingreso un valor valido"<<endl;
			system("pause");
			system("cls");
		}else{
			num = op1 - '0';
			MenuABML(num);		
		}
	}while(true);
}

int main(){
	Menu();
	return 0;
}
