/*
Un archivo binario PRODUCTOS.DAT contiene la informacion de los productos vendidos en el supermecado, consistentes en codigo de articulo (int), proveedor(char de 30) y precio(float).
En otro archivo binario AUMENTOS.DAT se encuentra un vector de estructuras conformadas por nombre de proveedor(char de 30) y un porcentaje(float).

Se pide aplicar a los productos del primer archivo los porcentajes de aumento indicados en el segundo archivo.

Todos los productos de un mismo proveedor deben recibir el aumento indicado en el segundo archivo.
*/
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct producto
{
    int codigo;
    char proveedor[30];
    float precio;
};

struct aumentos
{
    char proveedor[30];
    float aumento;
};

int main()
{
    FILE * BDPRODUCTOS;
    FILE * BDAUMENTOS;
    struct producto x;
    struct aumentos y;
    int cont = 0;
    float porcentaje = 0;

    BDPRODUCTOS = fopen("PRODUCTOS","rb+");
    BDAUMENTOS = fopen("AUMENTOS","rb");

    if(BDPRODUCTOS == NULL)
    {
        printf("El archivo no existe !");
        exit(-1);
    }

    if(BDAUMENTOS == NULL)
    {
        printf("El archivo no existe !");
        exit(-2);
    }

    printf("\n\tPRODUCTOS");
    fread(&x, sizeof(x), 1, BDPRODUCTOS);
    while(!feof(BDPRODUCTOS))
    {
        printf("\nCODIGO: %d", x.codigo);
        printf("\nPROVEEDOR: %s", x.proveedor);
        printf("\nPRECIO: %.2f", x.precio);
        printf("\n");

        fread(&x, sizeof(x), 1, BDPRODUCTOS);
    }

    printf("\n\tAUMENTOS");
    fread(&y, sizeof(y), 1, BDAUMENTOS);
    while(!feof(BDAUMENTOS))
    {
        printf("\nPROVEEDOR: %s", y.proveedor);
        printf("\nPRECIO: %.2f", y.aumento);
        printf("\n");

        fread(&y, sizeof(y), 1, BDAUMENTOS);
    }

    cont = ftell(BDPRODUCTOS) / sizeof(x);

    rewind(BDAUMENTOS);
    fread(&y, sizeof(y), 1, BDAUMENTOS);
    while(!feof(BDAUMENTOS))
    {
        rewind(BDPRODUCTOS);
        for(int i = 0; i < cont; i ++)
        {
            fseek(BDPRODUCTOS, i * sizeof(x), SEEK_SET);
            fread(&x, sizeof(x), 1, BDPRODUCTOS);
            porcentaje = (x.precio * y.aumento) / 100;
            if(strcmpi(y.proveedor, x.proveedor)==0)
            {
                fseek(BDPRODUCTOS, (-1) * sizeof(x), SEEK_CUR);
                x.precio += porcentaje;
                fwrite(&x, sizeof(x), 1, BDPRODUCTOS);
            }
        }
        fread(&y, sizeof(y), 1, BDAUMENTOS);
    }

    printf("\n\tPRODUCTOS CORREGIDOS");
    rewind(BDPRODUCTOS);
    fread(&x, sizeof(x), 1, BDPRODUCTOS);
    while(!feof(BDPRODUCTOS))
    {
        printf("\nCODIGO: %d", x.codigo);
        printf("\nPROVEEDOR: %s", x.proveedor);
        printf("\nPRECIO: %.2f", x.precio);
        printf("\n");

        fread(&x, sizeof(x), 1, BDPRODUCTOS);
    }

    fclose(BDPRODUCTOS);
    fclose(BDAUMENTOS);

    return 0;
}
