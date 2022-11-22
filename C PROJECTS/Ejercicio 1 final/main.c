#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#define num 3
#define viajes 8

struct fecha
{
    int dia;
    int mes;
    int anio;
};

struct viajecamion
{
    char patente[10];
    char ciudad_origen[50];
    char ciudad_destino[50];
    float peso_transportado;
    struct fecha fecha_viaje;
};

void inicializar(struct viajecamion [], int );
void ingreso(struct viajecamion [], int );
void mostrar_patentes(struct viajecamion [], int );
void maxPatente(struct viajecamion[], int );

int main()
{
    struct viajecamion vec[num];

    inicializar(vec, num);
    ingreso(vec, num);
    mostrar_patentes(vec, num);
    maxPatente(vec, num);
    ordenamiento(vec, num);

    return 0;
}
void inicializar(struct viajecamion v[], int n)
{
    for(int i = 0; i < n; i ++)
    {
        strcpy(v[i].patente, "");
        strcpy(v[i].ciudad_origen,"");
        strcpy(v[i].ciudad_destino,"");
        v[i].peso_transportado = 0;
        v[i].fecha_viaje.dia = 0;
        v[i].fecha_viaje.mes = 0;
        v[i].fecha_viaje.anio = 0;
    }
}
void ingreso(struct viajecamion v[], int n)
{
    for(int i = 0; i < n; i ++)
    {
        printf("Ingrese su patente: ");
        fflush(stdin);
        gets(v[i].patente);

        printf("Ingrese la ciudada de origen: ");
        fflush(stdin);
        gets(v[i].ciudad_origen);

        printf("Ingrese la ciudad del destino: ");
        fflush(stdin);
        gets(v[i].ciudad_destino);

        printf("Ingrese el peso: ");
        fflush(stdin);
        scanf("%f", &v[i].peso_transportado);

        printf("Ingrese la fecha del viaje (dd/mm/aaaa): ");
        fflush(stdin);
        scanf("%d/%d/%d", &v[i].fecha_viaje.dia, &v[i].fecha_viaje.mes, &v[i].fecha_viaje.anio);

        printf("\n");
    }
}
void mostrar_patentes(struct viajecamion v[], int n)
{
    int registrada = 0;
    char patentes[10][10] = {""};

    printf("\nLas patentes ingresadas son: ");

    for(int i = 0; i < n; i++)
    {
        registrada = 0;
        if(i == 0)
        {
            printf("\n%s\n", v[i].patente);
            strcpy(patentes[i], v[i].patente);
        }
        else
        {
            for(int j = 0; j < 10; j++)
            {
               if(strcmp(patentes[j], v[i].patente) == 0)
               {
                   registrada = 1;
                   break;
               }
            }
            if(registrada == 0)
            {
                printf("%s\n", v[i].patente);
                strcpy(patentes[i], v[i].patente);
            }
        }
    }
    printf("\n");
}
void maxPatente(struct viajecamion v[], int n)
{
    int i, j, cantViajes = 0, auxMayor = 0;
    char mayorPatente[10];
    for(i = 0; i < n; i ++)
    {
        cantViajes = 0;
        for(j = 0; j < viajes; j ++)
        {
            if(strcmp(v[i].ciudad_origen, "") != 0)
            {
                cantViajes ++;
            }
        }
        if(cantViajes > auxMayor)
        {
            auxMayor = cantViajes;
            strcpy(mayorPatente, v[i].patente);
        }
    }
    printf("\nLa patente que mas viajes hizo fue: %s", mayorPatente);
    printf("\n");
}
void ordenamiento(struct viajecamion v[], int n)
{
    struct viajecamion aux;
    for(int i = 0; i < n - 1; i ++)
    {
        for(int j = 1 + i; j < n - 1; j++)
        {
            if(v[i].fecha_viaje.anio > v[j].fecha_viaje.anio ||
                   (v[i].fecha_viaje.anio == v[j].fecha_viaje.anio && v[i].fecha_viaje.mes > v[j].fecha_viaje.mes) ||
                   (v[i].fecha_viaje.anio == v[j].fecha_viaje.anio && v[i].fecha_viaje.mes == v[j].fecha_viaje.mes && v[i].fecha_viaje.dia == v[j].fecha_viaje.dia) ||
                   (v[i].fecha_viaje.anio == v[j].fecha_viaje.anio && v[i].fecha_viaje.mes == v[j].fecha_viaje.mes && v[i].fecha_viaje.dia == v[j].fecha_viaje.dia && v[i].peso_transportado > v[j].peso_transportado))
            {
                aux = v[i];
                v[i] = v[j];
                v[j] = aux;
            }
        }
    }
    for(int i = 0; i < n; i ++)
    {
        printf("\n%s %s %s %.2f %d %d %d",
               v[i].patente,
               v[i].ciudad_origen,
               v[i].ciudad_destino,
               v[i].peso_transportado,
               v[i].fecha_viaje.anio,
               v[i].fecha_viaje.mes,
               v[i].fecha_viaje.dia);
    }
}

