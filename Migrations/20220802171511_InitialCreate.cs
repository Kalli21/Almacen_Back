using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Almacen_Back.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AL_ALMACEN",
                columns: table => new
                {
                    cod_almacen = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nom_almacen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dir_almacen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tlf_almacen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_ALMACEN", x => x.cod_almacen);
                });

            migrationBuilder.CreateTable(
                name: "AL_CATEGORIA",
                columns: table => new
                {
                    Cod_categoria = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    nom_categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    des_categoria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_CATEGORIA", x => x.Cod_categoria);
                });

            migrationBuilder.CreateTable(
                name: "AL_GRUPO_ACCESO",
                columns: table => new
                {
                    Cod_grupo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_GRUPO_ACCESO", x => x.Cod_grupo);
                });

            migrationBuilder.CreateTable(
                name: "AL_TIPO_TRANSACCION",
                columns: table => new
                {
                    cod_tipo_transaccion = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    descripción = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ingreso = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_TIPO_TRANSACCION", x => x.cod_tipo_transaccion);
                });

            migrationBuilder.CreateTable(
                name: "AL_UND_MEDIDA",
                columns: table => new
                {
                    cod_und_medida = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    des_und_medida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_UND_MEDIDA", x => x.cod_und_medida);
                });

            migrationBuilder.CreateTable(
                name: "AL_PROVEEDOR",
                columns: table => new
                {
                    cod_proveedor = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    razon_social = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cod_categoria = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ciudad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    web = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    contacto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    beneficiario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    activo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RUC = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    codigoPostal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Posicion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    saludo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_PROVEEDOR", x => x.cod_proveedor);
                    table.ForeignKey(
                        name: "FK_AL_PROVEEDOR_AL_CATEGORIA_Cod_categoria",
                        column: x => x.Cod_categoria,
                        principalTable: "AL_CATEGORIA",
                        principalColumn: "Cod_categoria",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AL_GRUPO_CLAVE",
                columns: table => new
                {
                    cod_clave = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cod_funcionario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cod_grupo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    clave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apoya_a = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ppp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_GRUPO_CLAVE", x => x.cod_clave);
                    table.ForeignKey(
                        name: "FK_AL_GRUPO_CLAVE_AL_GRUPO_ACCESO_Cod_grupo",
                        column: x => x.Cod_grupo,
                        principalTable: "AL_GRUPO_ACCESO",
                        principalColumn: "Cod_grupo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AL_ARTICULO",
                columns: table => new
                {
                    cod_articulo = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_und_medida = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Cod_categoria = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    nom_articulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    des_articulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    perecible = table.Column<bool>(type: "bit", nullable: false),
                    ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    estado = table.Column<bool>(type: "bit", nullable: false),
                    Imagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    precio_promedio_ref = table.Column<double>(type: "float", nullable: true),
                    precio_ultimo_ref = table.Column<double>(type: "float", nullable: true),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    visible = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_ARTICULO", x => x.cod_articulo);
                    table.ForeignKey(
                        name: "FK_AL_ARTICULO_AL_CATEGORIA_Cod_categoria",
                        column: x => x.Cod_categoria,
                        principalTable: "AL_CATEGORIA",
                        principalColumn: "Cod_categoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AL_ARTICULO_AL_UND_MEDIDA_cod_und_medida",
                        column: x => x.cod_und_medida,
                        principalTable: "AL_UND_MEDIDA",
                        principalColumn: "cod_und_medida",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AL_INGRESO_SALIDA",
                columns: table => new
                {
                    id_transaccion = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_clave = table.Column<long>(type: "bigint", nullable: false),
                    ingreso = table.Column<bool>(type: "bit", nullable: false),
                    cod_tipo_transaccion = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    num_guia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_transaccion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    cod_proveedor = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    cod_almacen = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    procesado = table.Column<bool>(type: "bit", nullable: false),
                    pendiente = table.Column<bool>(type: "bit", nullable: false),
                    fecha_proceso = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_INGRESO_SALIDA", x => x.id_transaccion);
                    table.ForeignKey(
                        name: "FK_AL_INGRESO_SALIDA_AL_ALMACEN_cod_almacen",
                        column: x => x.cod_almacen,
                        principalTable: "AL_ALMACEN",
                        principalColumn: "cod_almacen",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AL_INGRESO_SALIDA_AL_PROVEEDOR_cod_proveedor",
                        column: x => x.cod_proveedor,
                        principalTable: "AL_PROVEEDOR",
                        principalColumn: "cod_proveedor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AL_INGRESO_SALIDA_AL_TIPO_TRANSACCION_cod_tipo_transaccion",
                        column: x => x.cod_tipo_transaccion,
                        principalTable: "AL_TIPO_TRANSACCION",
                        principalColumn: "cod_tipo_transaccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AL_INGRESO",
                columns: table => new
                {
                    id_ingreso = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_clave = table.Column<long>(type: "bigint", nullable: false),
                    cod_proveedor = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    cod_almacen = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Num_guia_ingreso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Importacion = table.Column<bool>(type: "bit", nullable: false),
                    Fecha_ingreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_INGRESO", x => x.id_ingreso);
                    table.ForeignKey(
                        name: "FK_AL_INGRESO_AL_ALMACEN_cod_almacen",
                        column: x => x.cod_almacen,
                        principalTable: "AL_ALMACEN",
                        principalColumn: "cod_almacen",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AL_INGRESO_AL_GRUPO_CLAVE_cod_clave",
                        column: x => x.cod_clave,
                        principalTable: "AL_GRUPO_CLAVE",
                        principalColumn: "cod_clave",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AL_INGRESO_AL_PROVEEDOR_cod_proveedor",
                        column: x => x.cod_proveedor,
                        principalTable: "AL_PROVEEDOR",
                        principalColumn: "cod_proveedor",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AL_PEDIDO",
                columns: table => new
                {
                    id_pedido = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_clave = table.Column<long>(type: "bigint", nullable: false),
                    cod_almacen = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    fecha_pedido = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fecha_entrega = table.Column<DateTime>(type: "datetime2", nullable: true),
                    fecha_despacho = table.Column<DateTime>(type: "datetime2", nullable: true),
                    piso_destino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    proc_destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prog_destino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    proy_destino = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    motivo_solicitud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    autorizado = table.Column<bool>(type: "bit", nullable: false),
                    urgente = table.Column<bool>(type: "bit", nullable: false),
                    recepcionado = table.Column<bool>(type: "bit", nullable: false),
                    enviado = table.Column<bool>(type: "bit", nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    atendido = table.Column<bool>(type: "bit", nullable: false),
                    pedido_por = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_PEDIDO", x => x.id_pedido);
                    table.ForeignKey(
                        name: "FK_AL_PEDIDO_AL_ALMACEN_cod_almacen",
                        column: x => x.cod_almacen,
                        principalTable: "AL_ALMACEN",
                        principalColumn: "cod_almacen",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AL_PEDIDO_AL_GRUPO_CLAVE_cod_clave",
                        column: x => x.cod_clave,
                        principalTable: "AL_GRUPO_CLAVE",
                        principalColumn: "cod_clave",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AL_SALIDA",
                columns: table => new
                {
                    id_salida = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_clave = table.Column<long>(type: "bigint", nullable: false),
                    cod_almacen = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    num_guia_salida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    despacho_pedido = table.Column<bool>(type: "bit", nullable: false),
                    donacion = table.Column<bool>(type: "bit", nullable: false),
                    venta = table.Column<bool>(type: "bit", nullable: false),
                    Fecha_salida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_SALIDA", x => x.id_salida);
                    table.ForeignKey(
                        name: "FK_AL_SALIDA_AL_ALMACEN_cod_almacen",
                        column: x => x.cod_almacen,
                        principalTable: "AL_ALMACEN",
                        principalColumn: "cod_almacen",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AL_SALIDA_AL_GRUPO_CLAVE_cod_clave",
                        column: x => x.cod_clave,
                        principalTable: "AL_GRUPO_CLAVE",
                        principalColumn: "cod_clave",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AL_USER",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_clave = table.Column<long>(type: "bigint", nullable: false),
                    activo = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_USER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AL_USER_AL_GRUPO_CLAVE_cod_clave",
                        column: x => x.cod_clave,
                        principalTable: "AL_GRUPO_CLAVE",
                        principalColumn: "cod_clave",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AL_CONTROL_STOCK",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_almacen = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    cod_articulo = table.Column<long>(type: "bigint", nullable: false),
                    cant_fisica = table.Column<double>(type: "float", nullable: true),
                    cant_real = table.Column<double>(type: "float", nullable: true),
                    cant_minima_reposicion = table.Column<double>(type: "float", nullable: true),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_CONTROL_STOCK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AL_CONTROL_STOCK_AL_ALMACEN_cod_almacen",
                        column: x => x.cod_almacen,
                        principalTable: "AL_ALMACEN",
                        principalColumn: "cod_almacen",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AL_CONTROL_STOCK_AL_ARTICULO_cod_articulo",
                        column: x => x.cod_articulo,
                        principalTable: "AL_ARTICULO",
                        principalColumn: "cod_articulo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AL_DET_INGRESO_SALIDA",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_transaccion = table.Column<long>(type: "bigint", nullable: false),
                    cod_articulo = table.Column<long>(type: "bigint", nullable: false),
                    cant_articulo = table.Column<double>(type: "float", nullable: true),
                    costo_unitario = table.Column<double>(type: "float", nullable: true),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha_vencimiento = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_DET_INGRESO_SALIDA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AL_DET_INGRESO_SALIDA_AL_ARTICULO_cod_articulo",
                        column: x => x.cod_articulo,
                        principalTable: "AL_ARTICULO",
                        principalColumn: "cod_articulo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AL_DET_INGRESO_SALIDA_AL_INGRESO_SALIDA_id_transaccion",
                        column: x => x.id_transaccion,
                        principalTable: "AL_INGRESO_SALIDA",
                        principalColumn: "id_transaccion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AL_DET_INGRESO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cod_articulo = table.Column<long>(type: "bigint", nullable: false),
                    id_ingreso = table.Column<long>(type: "bigint", nullable: false),
                    cant_art_ingreso = table.Column<double>(type: "float", nullable: true),
                    prec_unit_ingreso = table.Column<double>(type: "float", nullable: true),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_DET_INGRESO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AL_DET_INGRESO_AL_ARTICULO_cod_articulo",
                        column: x => x.cod_articulo,
                        principalTable: "AL_ARTICULO",
                        principalColumn: "cod_articulo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AL_DET_INGRESO_AL_INGRESO_id_ingreso",
                        column: x => x.id_ingreso,
                        principalTable: "AL_INGRESO",
                        principalColumn: "id_ingreso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AL_DET_PEDIDO",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_pedido = table.Column<long>(type: "bigint", nullable: false),
                    cod_articulo = table.Column<long>(type: "bigint", nullable: false),
                    cant_pedida = table.Column<double>(type: "float", nullable: true),
                    cant_aceptada = table.Column<double>(type: "float", nullable: true),
                    cant_entregada = table.Column<double>(type: "float", nullable: true),
                    cant_por_entregar = table.Column<double>(type: "float", nullable: true),
                    costo_cant_entrega = table.Column<double>(type: "float", nullable: true),
                    pedido_para_compra = table.Column<bool>(type: "bit", nullable: false),
                    autoriza_compra = table.Column<bool>(type: "bit", nullable: false),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_DET_PEDIDO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AL_DET_PEDIDO_AL_ARTICULO_cod_articulo",
                        column: x => x.cod_articulo,
                        principalTable: "AL_ARTICULO",
                        principalColumn: "cod_articulo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AL_DET_PEDIDO_AL_PEDIDO_id_pedido",
                        column: x => x.id_pedido,
                        principalTable: "AL_PEDIDO",
                        principalColumn: "id_pedido",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AL_DET_SALIDA",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_salida = table.Column<long>(type: "bigint", nullable: false),
                    cod_articulo = table.Column<long>(type: "bigint", nullable: false),
                    cant_articulo = table.Column<double>(type: "float", nullable: true),
                    precio_unit_salida = table.Column<double>(type: "float", nullable: true),
                    Obs = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AL_DET_SALIDA", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AL_DET_SALIDA_AL_ARTICULO_cod_articulo",
                        column: x => x.cod_articulo,
                        principalTable: "AL_ARTICULO",
                        principalColumn: "cod_articulo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AL_DET_SALIDA_AL_SALIDA_id_salida",
                        column: x => x.id_salida,
                        principalTable: "AL_SALIDA",
                        principalColumn: "id_salida",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PedidoSalida",
                columns: table => new
                {
                    Pedidoid_pedido = table.Column<long>(type: "bigint", nullable: false),
                    Salidaid_salida = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoSalida", x => new { x.Pedidoid_pedido, x.Salidaid_salida });
                    table.ForeignKey(
                        name: "FK_PedidoSalida_AL_PEDIDO_Pedidoid_pedido",
                        column: x => x.Pedidoid_pedido,
                        principalTable: "AL_PEDIDO",
                        principalColumn: "id_pedido",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PedidoSalida_AL_SALIDA_Salidaid_salida",
                        column: x => x.Salidaid_salida,
                        principalTable: "AL_SALIDA",
                        principalColumn: "id_salida",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AL_ARTICULO_Cod_categoria",
                table: "AL_ARTICULO",
                column: "Cod_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_AL_ARTICULO_cod_und_medida",
                table: "AL_ARTICULO",
                column: "cod_und_medida");

            migrationBuilder.CreateIndex(
                name: "IX_AL_CONTROL_STOCK_cod_almacen",
                table: "AL_CONTROL_STOCK",
                column: "cod_almacen");

            migrationBuilder.CreateIndex(
                name: "IX_AL_CONTROL_STOCK_cod_articulo",
                table: "AL_CONTROL_STOCK",
                column: "cod_articulo");

            migrationBuilder.CreateIndex(
                name: "IX_AL_DET_INGRESO_cod_articulo",
                table: "AL_DET_INGRESO",
                column: "cod_articulo");

            migrationBuilder.CreateIndex(
                name: "IX_AL_DET_INGRESO_id_ingreso",
                table: "AL_DET_INGRESO",
                column: "id_ingreso");

            migrationBuilder.CreateIndex(
                name: "IX_AL_DET_INGRESO_SALIDA_cod_articulo",
                table: "AL_DET_INGRESO_SALIDA",
                column: "cod_articulo");

            migrationBuilder.CreateIndex(
                name: "IX_AL_DET_INGRESO_SALIDA_id_transaccion",
                table: "AL_DET_INGRESO_SALIDA",
                column: "id_transaccion");

            migrationBuilder.CreateIndex(
                name: "IX_AL_DET_PEDIDO_cod_articulo",
                table: "AL_DET_PEDIDO",
                column: "cod_articulo");

            migrationBuilder.CreateIndex(
                name: "IX_AL_DET_PEDIDO_id_pedido",
                table: "AL_DET_PEDIDO",
                column: "id_pedido");

            migrationBuilder.CreateIndex(
                name: "IX_AL_DET_SALIDA_cod_articulo",
                table: "AL_DET_SALIDA",
                column: "cod_articulo");

            migrationBuilder.CreateIndex(
                name: "IX_AL_DET_SALIDA_id_salida",
                table: "AL_DET_SALIDA",
                column: "id_salida");

            migrationBuilder.CreateIndex(
                name: "IX_AL_GRUPO_CLAVE_Cod_grupo",
                table: "AL_GRUPO_CLAVE",
                column: "Cod_grupo");

            migrationBuilder.CreateIndex(
                name: "IX_AL_INGRESO_cod_almacen",
                table: "AL_INGRESO",
                column: "cod_almacen");

            migrationBuilder.CreateIndex(
                name: "IX_AL_INGRESO_cod_clave",
                table: "AL_INGRESO",
                column: "cod_clave");

            migrationBuilder.CreateIndex(
                name: "IX_AL_INGRESO_cod_proveedor",
                table: "AL_INGRESO",
                column: "cod_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_AL_INGRESO_SALIDA_cod_almacen",
                table: "AL_INGRESO_SALIDA",
                column: "cod_almacen");

            migrationBuilder.CreateIndex(
                name: "IX_AL_INGRESO_SALIDA_cod_proveedor",
                table: "AL_INGRESO_SALIDA",
                column: "cod_proveedor");

            migrationBuilder.CreateIndex(
                name: "IX_AL_INGRESO_SALIDA_cod_tipo_transaccion",
                table: "AL_INGRESO_SALIDA",
                column: "cod_tipo_transaccion");

            migrationBuilder.CreateIndex(
                name: "IX_AL_PEDIDO_cod_almacen",
                table: "AL_PEDIDO",
                column: "cod_almacen");

            migrationBuilder.CreateIndex(
                name: "IX_AL_PEDIDO_cod_clave",
                table: "AL_PEDIDO",
                column: "cod_clave");

            migrationBuilder.CreateIndex(
                name: "IX_AL_PROVEEDOR_Cod_categoria",
                table: "AL_PROVEEDOR",
                column: "Cod_categoria");

            migrationBuilder.CreateIndex(
                name: "IX_AL_SALIDA_cod_almacen",
                table: "AL_SALIDA",
                column: "cod_almacen");

            migrationBuilder.CreateIndex(
                name: "IX_AL_SALIDA_cod_clave",
                table: "AL_SALIDA",
                column: "cod_clave");

            migrationBuilder.CreateIndex(
                name: "IX_AL_USER_cod_clave",
                table: "AL_USER",
                column: "cod_clave");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoSalida_Salidaid_salida",
                table: "PedidoSalida",
                column: "Salidaid_salida");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AL_CONTROL_STOCK");

            migrationBuilder.DropTable(
                name: "AL_DET_INGRESO");

            migrationBuilder.DropTable(
                name: "AL_DET_INGRESO_SALIDA");

            migrationBuilder.DropTable(
                name: "AL_DET_PEDIDO");

            migrationBuilder.DropTable(
                name: "AL_DET_SALIDA");

            migrationBuilder.DropTable(
                name: "AL_USER");

            migrationBuilder.DropTable(
                name: "PedidoSalida");

            migrationBuilder.DropTable(
                name: "AL_INGRESO");

            migrationBuilder.DropTable(
                name: "AL_INGRESO_SALIDA");

            migrationBuilder.DropTable(
                name: "AL_ARTICULO");

            migrationBuilder.DropTable(
                name: "AL_PEDIDO");

            migrationBuilder.DropTable(
                name: "AL_SALIDA");

            migrationBuilder.DropTable(
                name: "AL_PROVEEDOR");

            migrationBuilder.DropTable(
                name: "AL_TIPO_TRANSACCION");

            migrationBuilder.DropTable(
                name: "AL_UND_MEDIDA");

            migrationBuilder.DropTable(
                name: "AL_ALMACEN");

            migrationBuilder.DropTable(
                name: "AL_GRUPO_CLAVE");

            migrationBuilder.DropTable(
                name: "AL_CATEGORIA");

            migrationBuilder.DropTable(
                name: "AL_GRUPO_ACCESO");
        }
    }
}
