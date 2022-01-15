CREATE TABLE tab_types (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL 
);

CREATE TABLE tab_products (
    id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    id_type INT NOT NULL,
    FOREIGN KEY (id_type) REFERENCES tab_types(id) 
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
);

-- Тестовые данные

-- Тестовые типы продуктов
INSERT INTO host1323541_sbd17.tab_types (name)
VALUES ('prod_1');

INSERT INTO host1323541_sbd17.tab_types (name)
VALUES ('prod_2');

INSERT INTO host1323541_sbd17.tab_types (name)
VALUES ('prod_3');

-- Тестовые продукты
INSERT INTO host1323541_sbd17.tab_products (name, id_type)
VALUES ('product_1', 1);

INSERT INTO host1323541_sbd17.tab_products (name, id_type)
VALUES ('product_2', 3);

INSERT INTO host1323541_sbd17.tab_products (name, id_type)
VALUES ('product_3', 2);

INSERT INTO host1323541_sbd17.tab_products (name, id_type)
VALUES ('product_4', 3);