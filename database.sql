
CREATE TABLE preco (
    id INT AUTO_INCREMENT PRIMARY KEY,
    valor_hora_inicial DECIMAL(10, 2) NOT NULL,
    valor_hora_adicional DECIMAL(10, 2) NOT NULL,
    data_inicio DATE NOT NULL,
    data_fim DATE NOT NULL
);

CREATE TABLE carro (
    num_placa VARCHAR(10) PRIMARY KEY,
    hora_entrada DATETIME,
    hora_saida DATETIME,
    duracao TIME,
    tempo_cobrado INT,
    preco DECIMAL(10, 2),
    valor DECIMAL(10, 2),
    preco_id INT
);

ALTER TABLE carro
    ADD CONSTRAINT fk_preco
    FOREIGN KEY (preco_id) REFERENCES preco(id);
