# WDBXEditor 2.0.0

![.NET](https://img.shields.io/badge/.NET-8.0-purple?style=flat&logo=dotnet)
![Platform](https://img.shields.io/badge/Platform-Windows-blue?style=flat&logo=windows)

Una versión modernizada y optimizada del clásico WDBXEditor, migrada completamente para aprovechar el rendimiento actual. Este programa es una herramienta comunitaria diseñada para editar todas las variantes de los archivos de base de datos del cliente de Blizzard (DBC, DB2, etc.). 

Ideal para la edición rápida y estable de tablas, modificación de archivos del cliente y texturas, brindando un entorno fluido tanto para proyectos en versiones clásicas como la 3.3.5a, así como para expansiones posteriores.

## 🚀 Novedades de esta versión

Este (*fork*) representa una actualización integral del proyecto original de WowDevTools. Se ha reescrito gran parte del código para mejorar la experiencia del usuario y la estabilidad.

### 🔧 Mejoras de Rendimiento y Sistema
* **Migración a .NET 8.0:** Salto tecnológico desde .NET 4.6.1, mejorando la velocidad de carga y gestión de memoria.
* **Limpieza profunda:** Eliminación total de funciones obsoletas y código heredado innecesario.
* **Optimización general:** Reducción de redundancias en el código fuente para hacer la herramienta mucho más ligera y mantenible.
* **Múltiples Instancias y Pestañas:** Se ha reestructurado la lógica de inicio para soportar múltiples ventanas independientes al mismo tiempo, sin sacrificar la capacidad de acoplar pestañas.

### ✨ Nuevas Funciones y Usabilidad
* **Flujo de trabajo estilo Excel:** Soporte total para selección múltiple y atajos de teclado (Ctrl+C, Ctrl+X, Ctrl+D, Ctrl+Shift+Flechas), permitiendo editar datos masivamente igual que en una hoja de cálculo.
* **Borrado rápido:** Ahora puedes vaciar los datos de cualquier celda simplemente seleccionándola y presionando la tecla `Suprimir` (Delete).
* **Modo Oscuro:** Nueva interfaz oscura integrada para reducir la fatiga visual al editar bases de datos extensas. El tema cambia dinámicamente y recuerda tu preferencia entre sesiones.
* **Sistema de idioma inteligente:** Detecta automáticamente el idioma de tu sistema operativo al iniciar y guarda tus preferencias.
* **Soporte Multiidioma:** Disponible en 9 idiomas: 🇺🇸 Inglés, 🇪🇸 Español, 🇧🇷 Portugués, 🇫🇷 Francés, 🇩🇪 Alemán, 🇮🇹 Italiano, 🇷🇺 Ruso, 🇨🇳 Chino y 🇰🇷 Coreano.

### 🛡️ Motor de Datos y CSV (Excel-Safe)
* **Importación/Exportación reescrita:** El motor CSV ha sido creado desde cero para ser 100% seguro al abrirse en Excel.
* **Textos multilínea nativos:** Transforma automáticamente los saltos de línea nativos de WoW (`\r\n`) a saltos suaves (`\n`), evitando definitivamente las columnas rotas.
* **Cultura Invariante:** Adiós al problema de las comas y los puntos. Exporta e importa multiplicadores y valores flotantes (*floats*) con precisión clínica, sin importar la configuración regional de tu Windows.
* **Seguridad Null-Safe:** El editor detecta celdas numéricas vacías y les asigna automáticamente los valores binarios correctos que requiere el cliente del juego.

---

> ⚠️ **Nota técnica sobre rendimiento:** Gracias a las nuevas funciones estilo Excel, ahora es posible copiar y pegar datos de forma masiva. Sin embargo, al procesar volúmenes extremadamente altos (más de 10k celdas simultáneas), la interfaz puede demorar algunos minutos en completar la acción debido a las limitaciones nativas de renderizado de WinForms.

## 📜 Créditos

* Proyecto original creado por [WowDevTools](https://github.com/WowDevTools/WDBXEditor).
* Migración a .NET 8.0, optimización y nuevas funciones por [Mapache-Warmane2077](https://github.com/Mapache-Warmane2077).
