CREATE TABLE tb_fiap_gs_usuario (
    nr_id_user   INTEGER NOT NULL,
    nm_user      VARCHAR2(32 CHAR) NOT NULL,
    ds_endereco  VARCHAR2(100 CHAR) NOT NULL,
    nr_cpf       INTEGER NOT NULL,
    ds_email     VARCHAR2(50 CHAR) NOT NULL,
    nr_telefone  INTEGER,
    nr_rg        INTEGER,
    nr_pontos    INTEGER
);

ALTER TABLE tb_fiap_gs_usuario ADD CONSTRAINT tb_fiap_gs_usuario_pk PRIMARY KEY ( nr_id_user );

CREATE TABLE tb_fiap_gs_parceiro (
    nr_id_parceiro      INTEGER NOT NULL,
    nr_cnpj             INTEGER NOT NULL,
    dt_inicio_parceria  DATE NOT NULL,
    dt_termino          DATE NOT NULL,
    ds_endereco         VARCHAR2(100 CHAR) NOT NULL,
    nm_parceiro         VARCHAR2(32),
    nr_telefone         INTEGER
);

ALTER TABLE tb_fiap_gs_parceiro ADD CONSTRAINT tb_fiap_gs_parceiro_pk PRIMARY KEY ( nr_id_parceiro );



CREATE TABLE tb_fiap_gs_veiculo (
    nr_placa        INTEGER NOT NULL,
    nr_id_parceiro  INTEGER NOT NULL,
    nr_id_user      INTEGER NOT NULL,
    nm_fabricante   VARCHAR2(32 CHAR) NOT NULL,
    nm_modelo       VARCHAR2(32 CHAR) NOT NULL
);

ALTER TABLE tb_fiap_gs_veiculo ADD CONSTRAINT tb_fiap_gs_veiculo_pk PRIMARY KEY ( nr_placa );



ALTER TABLE tb_fiap_gs_veiculo
    ADD CONSTRAINT join_veic_parc FOREIGN KEY ( nr_id_parceiro )
        REFERENCES tb_fiap_gs_parceiro ( nr_id_parceiro );

ALTER TABLE tb_fiap_gs_veiculo
    ADD CONSTRAINT join_veic_usr FOREIGN KEY ( nr_id_user )
        REFERENCES tb_fiap_gs_usuario ( nr_id_user );
