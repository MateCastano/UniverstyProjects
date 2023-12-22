/*

EL ARCHIVO BDPEREZ ESTA COMPUESTO POR REGISTROS DE LA FORMA struct ARTICULO.
EL PROVEEDOR PEREZ SOLO COMERCIALIZA UN ARTICULO
SE REQUIERE DEPURAR LA BD DE FORMA DE ELIMINAR TODOS LOS ARTICULOS
DE LOS PROVEEDORES QUE COMERCIALICEN EL MISMO ARTICULO DE PEREZ
ES DECIR, BORRAR DEL MAPA A LA COMPETENCIA EN TODOS SUS ARTICULOS
TENER CUIDADO DE NO ELIMINAR A PEREZ
INDICAR CUANTOS REGISTROS QUEDARON

*/
#include <stdio.h>
#include <stdlib.h>
#include <string.h>

struct ARTICULO
{
    int NUMART ;
    char DESCRIP[20];
    int STOCK ;
    char PROVE[15] ;
    float COSTO ;
};

int main()
{
    FILE * BDPEREZ;
    FILE * BDAUX;
    struct ARTICULO x;
    char articuloBuscado[30];

    BDPEREZ = fopen("BDPEREZ", "rb+");
    BDAUX = fopen("BDPEREZAUX", "wb+");

    if(BDPEREZ == NULL)
    {
        printf("El archivo fallo !");
        exit(-1);
    }

    printf("ARCHIVO\n");
    fread(&x, sizeof(x), 1, BDPEREZ);
    while(!feof(BDPEREZ))
    {
        if(strcmpi(x.DESCRIP,"CARAMELOS")==0)
        {
            printf("\nNUMERO ARTICULO: %d", x.NUMART);
            printf("\nDESCRIPCION: %s", x.DESCRIP);
            printf("\nSTOCK: %d", x.STOCK);
            printf("\nPROVEEDOR: %s", x.PROVE);
            printf("\nPRECIO: %.2f\n", x.COSTO);
        }
        fread(&x, sizeof(x), 1, BDPEREZ);
    }

    /*rewind(BDPEREZ);
    fread(&x, sizeof(x), 1, BDPEREZ);
    while(!feof(BDPEREZ))
    {
        if(strcmpi(x.PROVE,"PEREZ")==0)
        {
            strcpy(articuloBuscado, x.DESCRIP);
        }
        fread(&x, sizeof(x), 1, BDPEREZ);
    }

    fseek(BDPEREZ, 0l, SEEK_SET);
    fread(&x, sizeof(x), 1, BDPEREZ);

    while( !feof(BDPEREZ) )
    {
        if(strcmp(articuloBuscado, x.DESCRIP) != 0 || strcmpi(x.PROVE, "PEREZ") == 0)
        {
            fseek(BDPEREZ, (-1) * sizeof(x), SEEK_SET);
            fwrite(&x, sizeof(x), 1, BDAUX);
        }
        fread(&x, sizeof(x), 1, BDPEREZ);
    }

    remove("BDPEREZ");
    rename("BDPEREZAUX", "BDPEREZ");*/

    fclose(BDPEREZ);

    return 0;
}
