CREATE TABLE Empleados (
    id INT PRIMARY KEY,
    nombre VARCHAR(50),
    salario DECIMAL(10, 2)
);

INSERT INTO Empleados (id, nombre, salario) VALUES (1, 'Juan', 3000.00);

SELECT * FROM Empleados WHERE salario > 2000;
