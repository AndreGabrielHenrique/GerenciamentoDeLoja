-- Para criar o BD
CREATE DATABASE dbGerenciamentoDeLoja;
-- Para selecionar o BD
USE dbGerenciamentoDeLoja;
-- Criando a tabela Produtos dentro do BD
CREATE TABLE Produtos
(
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(200) NOT NULL,
    marca VARCHAR(200) NOT NULL,
    preco DECIMAL(10,2) NOT NULL,
    validade DATETIME
);
-- Trigger para validar as colunas preco e validade
CREATE TRIGGER ValidacaoProdutos
BEFORE INSERT ON Produtos
FOR EACH ROW
BEGIN
  DECLARE FormatoIncorreto BOOLEAN;
  -- Formato de validação para preço
  SET FormatoIncorreto=NEW.preco NOT REGEXP '^[0-9]$';
  IF FormatoIncorreto THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='Formato de preço incorreto.';
  END IF;
  -- Formato de validação para validade
  SET FormatoIncorreto = NEW.validade NOT REGEXP '^[0-9]$';
  IF FormatoIncorreto THEN
    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT='Formato de data de validade incorreto.';
  END IF;
END;