using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace WDBXEditor
{
    public static class LanguageManager
    {
        // La variable global ahora no tiene un valor inicial fijo, lo calcularemos.
        public static string IdiomaActual { get; set; }

        // 1. Aquí va tu diccionario con todos los idiomas (Mantenlo tal cual lo tienes)
        private static readonly Dictionary<string, Dictionary<string, string>> TRANSLATIONS = new()
        {
            { "es", new Dictionary<string, string> {
                // Menús Principales
                { "fileToolStripMenuItem", "Archivo" },
                { "editToolStripMenuItem", "Editar" },
                { "optionsToolStripMenuItem", "Herramientas" },
                { "exportToolStripMenuItem", "Exportar" },
                { "importToolStripMenuItem", "Importar" },
                { "helpToolStripMenuItem", "Configuración" },
                { "idiomaToolStripMenuItem", "Idioma" },

                // Sub-menús de Archivo
                { "loadFilesToolStripMenuItem", "Cargar Archivos..." },
                { "recentToolStripMenuItem", "Archivos Recientes" },
                { "openFromMPQToolStripMenuItem", "Abrir desde MPQ..." },
                { "openFromCASCToolStripMenuItem", "Abrir desde CASC..." },
                { "saveToolStripMenuItem", "Guardar" },
                { "saveAsToolStripMenuItem", "Guardar Como..." },
                { "saveAllToolStripMenuItem", "Guardar Todo" },
                { "reloadToolStripMenuItem", "Recargar" },
                { "closeToolStripMenuItem", "Cerrar" },
                { "closeAllToolStripMenuItem", "Cerrar Todo" },

                // Sub-menús de Editar
                { "undoToolStripMenuItem", "Deshacer" },
                { "redoToolStripMenuItem", "Rehacer" },
                { "insertLineToolStripMenuItem", "Insertar Línea" },
                { "insertToolStripMenuItem", "Insertar Línea" }, // WDBX tiene dos botones de insertar
                { "newLineToolStripMenuItem", "Nueva Línea" },
                { "findToolStripMenuItem", "Buscar..." },
                { "replaceToolStripMenuItem", "Reemplazar..." },
                { "goToToolStripMenuItem", "Ir a..." },

                // Sub-menús de Importar/Exportar
                { "fromCSVToolStripMenuItem", "Desde archivo CSV" },
                { "fromSQLToolStripMenuItem", "Desde servidor SQL" },
                { "toCSVToolStripMenuItem", "A archivo CSV" },
                { "toSQLToolStripMenuItem", "A tabla SQL" },
                { "toSQLFileToolStripMenuItem", "A archivo SQL" },
                { "toMPQToolStripMenuItem", "A archivo MPQ" },
                { "toJSONToolStripMenuItem", "A archivo JSON" },

                // Herramientas
                { "editDefinitionsToolStripMenuItem", "Editor de Definiciones" },
                { "wotLKItemFixToolStripMenuItem", "Importar Items (WotLK)" },
                { "legionToolStripMenuItem", "Parser de Legion" },
                { "playerLocationRecorderToolStripMenuItem", "Grabador de Ubicación" },
                { "colourPickerToolStripMenuItem", "Selector de Color" },
                
                // Etiquetas de la interfaz visual y Botones
                { "btnReset", "Restablecer" },
                { "gbSettings", "Estadísticas" }, 
                
                // Nombres genéricos
                { "label7", "Filtro" },
                { "label6", "Build" },
                { "label1", "Archivo Actual:" },
                { "label2", "Definición:" },
                { "label4", "Celda Actual:" },
                { "label5", "Estadísticas:" },

                // Otros
                { "aboutToolStripMenuItem", "Acerca de..." },
                { "msgAcoplarArchivosCuerpo", "¿Deseas acoplar los archivos a esta ventana?\n\n SI = Acoplar en pestaña\n NO = Abrir en nueva ventana" },
                { "msgAcoplarArchivosTitulo", "Acoplar archivo(s) DBC" },
                { "msgCambiosSinGuardarCuerpo", "Tienes cambios sin guardar. ¿Deseas salir?" },
                { "msgCambiosSinGuardarTitulo", "Cambios sin guardar" },
				// Textos de Columnas
                { "label8", "Modo de columnas:" },
                { "label3", "Columnas:" },
            }},
            { "en", new Dictionary<string, string> {
                // Menús Principales
                { "fileToolStripMenuItem", "File" },
                { "editToolStripMenuItem", "Edit" },
                { "optionsToolStripMenuItem", "Tools" },
                { "exportToolStripMenuItem", "Export" },
                { "importToolStripMenuItem", "Import" },
                { "helpToolStripMenuItem", "Settings" },
                { "idiomaToolStripMenuItem", "Language" },

                // Sub-menús de Archivo
                { "loadFilesToolStripMenuItem", "Load Files..." },
                { "recentToolStripMenuItem", "Recent Files" },
                { "openFromMPQToolStripMenuItem", "Open from MPQ..." },
                { "openFromCASCToolStripMenuItem", "Open from CASC..." },
                { "saveToolStripMenuItem", "Save" },
                { "saveAsToolStripMenuItem", "Save As..." },
                { "saveAllToolStripMenuItem", "Save All" },
                { "reloadToolStripMenuItem", "Reload" },
                { "closeToolStripMenuItem", "Close" },
                { "closeAllToolStripMenuItem", "Close All" },

                // Sub-menús de Editar
                { "undoToolStripMenuItem", "Undo" },
                { "redoToolStripMenuItem", "Redo" },
                { "insertLineToolStripMenuItem", "Insert Line" },
                { "insertToolStripMenuItem", "Insert Line" },
                { "newLineToolStripMenuItem", "New Line" },
                { "findToolStripMenuItem", "Find..." },
                { "replaceToolStripMenuItem", "Replace..." },
                { "goToToolStripMenuItem", "Go to..." },

                // Sub-menús de Importar/Exportar
                { "fromCSVToolStripMenuItem", "From CSV file" },
                { "fromSQLToolStripMenuItem", "From SQL server" },
                { "toCSVToolStripMenuItem", "To CSV file" },
                { "toSQLToolStripMenuItem", "To SQL table" },
                { "toSQLFileToolStripMenuItem", "To SQL file" },
                { "toMPQToolStripMenuItem", "To MPQ file" },
                { "toJSONToolStripMenuItem", "To JSON file" },

                // Herramientas
                { "editDefinitionsToolStripMenuItem", "Definition Editor" },
                { "wotLKItemFixToolStripMenuItem", "(WotLK) Item Import" },
                { "legionToolStripMenuItem", "Legion Parser" },
                { "playerLocationRecorderToolStripMenuItem", "Player Location Recorder" },
                { "colourPickerToolStripMenuItem", "Colour Picker" },
                
                // Etiquetas de la interfaz visual y Botones
                { "btnReset", "Reset" },
                { "gbSettings", "Statistics" }, 
                
                // Nombres genéricos
                { "label7", "Filter" },
                { "label6", "Build" },
                { "label1", "Current File:" },
                { "label2", "Definition:" },
                { "label4", "Current Cell:" },
                { "label5", "Stats:" },

                // Otros
                { "aboutToolStripMenuItem", "About..." },
                { "msgAcoplarArchivosCuerpo", "Do you want to dock the files to this window?\n\n YES = Dock in tab\n NO = Open in new window" },
                { "msgAcoplarArchivosTitulo", "Dock DBC file(s)" },
                { "msgCambiosSinGuardarCuerpo", "You have unsaved changes. Do you wish to exit?" },
                { "msgCambiosSinGuardarTitulo", "Unsaved Changes" },
                // Textos de Columnas
                { "label8", "Columns mode:" },
                { "label3", "Columns:" },
            }},

            { "it", new Dictionary<string, string> {
            // Menús Principales
            { "fileToolStripMenuItem", "File" },
            { "editToolStripMenuItem", "Modifica" },
            { "optionsToolStripMenuItem", "Strumenti" },
            { "exportToolStripMenuItem", "Esporta" },
            { "importToolStripMenuItem", "Importa" },
            { "helpToolStripMenuItem", "Impostazioni" },
            { "idiomaToolStripMenuItem", "Lingua" },

            // Sub-menús de Archivo
            { "loadFilesToolStripMenuItem", "Carica file..." },
            { "recentToolStripMenuItem", "File recenti" },
            { "openFromMPQToolStripMenuItem", "Apri da MPQ..." },
            { "openFromCASCToolStripMenuItem", "Apri da CASC..." },
            { "saveToolStripMenuItem", "Salva" },
            { "saveAsToolStripMenuItem", "Salva con nome..." },
            { "saveAllToolStripMenuItem", "Salva tutto" },
            { "reloadToolStripMenuItem", "Ricarica" },
            { "closeToolStripMenuItem", "Chiudi" },
            { "closeAllToolStripMenuItem", "Chiudi tutto" },

            // Sub-menús de Editar
            { "undoToolStripMenuItem", "Annulla" },
            { "redoToolStripMenuItem", "Ripeti" },
            { "insertLineToolStripMenuItem", "Inserisci riga" },
            { "insertToolStripMenuItem", "Inserisci riga" },
            { "newLineToolStripMenuItem", "Nuova riga" },
            { "findToolStripMenuItem", "Trova..." },
            { "replaceToolStripMenuItem", "Sostituisci..." },
            { "goToToolStripMenuItem", "Vai a..." },

            // Sub-menús de Importar/Exportar
            { "fromCSVToolStripMenuItem", "Da file CSV" },
            { "fromSQLToolStripMenuItem", "Da server SQL" },
            { "toCSVToolStripMenuItem", "In file CSV" },
            { "toSQLToolStripMenuItem", "In tabella SQL" },
            { "toSQLFileToolStripMenuItem", "In file SQL" },
            { "toMPQToolStripMenuItem", "In file MPQ" },
            { "toJSONToolStripMenuItem", "In file JSON" },

            // Herramientas
            { "editDefinitionsToolStripMenuItem", "Editor di definizioni" },
            { "wotLKItemFixToolStripMenuItem", "Importa oggetti (WotLK)" },
            { "legionToolStripMenuItem", "Parser di Legion" },
            { "playerLocationRecorderToolStripMenuItem", "Registratore posizione giocatore" },
            { "colourPickerToolStripMenuItem", "Selettore colore" },
                
            // Etiquetas de la interfaz visual y Botones
            { "btnReset", "Ripristina" },
            { "gbSettings", "Statistiche" }, 
                
            // Nombres genéricos
            { "label7", "Filtro" },
            { "label6", "Build" },
            { "label1", "File corrente:" },
            { "label2", "Definizione:" },
            { "label4", "Cella corrente:" },
            { "label5", "Statistiche:" },

            // Otros
            { "aboutToolStripMenuItem", "Informazioni su..." },
            { "msgAcoplarArchivosCuerpo", "Vuoi ancorare i file a questa finestra?\n\n SÌ = Ancora nella scheda\n NO = Apri in una nuova finestra" },
            { "msgAcoplarArchivosTitulo", "Ancora file DBC" },
            { "msgCambiosSinGuardarCuerpo", "Hai modifiche non salvate. Vuoi uscire?" },
            { "msgCambiosSinGuardarTitulo", "Modifiche non salvate" },
            // Textos de Columnas
            { "label8", "Modalità colonne:" },
            { "label3", "Colonne:" },
            }},

            { "pt", new Dictionary<string, string> {
                { "fileToolStripMenuItem", "Arquivo" },
                { "editToolStripMenuItem", "Editar" },
                { "optionsToolStripMenuItem", "Ferramentas" },
                { "exportToolStripMenuItem", "Exportar" },
                { "importToolStripMenuItem", "Importar" },
                { "helpToolStripMenuItem", "Configurações" },
                { "idiomaToolStripMenuItem", "Idioma" },
                { "loadFilesToolStripMenuItem", "Carregar Arquivos..." },
                { "recentToolStripMenuItem", "Arquivos Recentes" },
                { "openFromMPQToolStripMenuItem", "Abrir do MPQ..." },
                { "openFromCASCToolStripMenuItem", "Abrir do CASC..." },
                { "saveToolStripMenuItem", "Salvar" },
                { "saveAsToolStripMenuItem", "Salvar Como..." },
                { "saveAllToolStripMenuItem", "Salvar Tudo" },
                { "reloadToolStripMenuItem", "Recarregar" },
                { "closeToolStripMenuItem", "Fechar" },
                { "closeAllToolStripMenuItem", "Fechar Tudo" },
                { "undoToolStripMenuItem", "Desfazer" },
                { "redoToolStripMenuItem", "Refazer" },
                { "insertLineToolStripMenuItem", "Inserir Linha" },
                { "insertToolStripMenuItem", "Inserir Linha" },
                { "newLineToolStripMenuItem", "Nova Linha" },
                { "findToolStripMenuItem", "Localizar..." },
                { "replaceToolStripMenuItem", "Substituir..." },
                { "goToToolStripMenuItem", "Ir para..." },
                { "fromCSVToolStripMenuItem", "Do arquivo CSV" },
                { "fromSQLToolStripMenuItem", "Do servidor SQL" },
                { "toCSVToolStripMenuItem", "Para arquivo CSV" },
                { "toSQLToolStripMenuItem", "Para tabela SQL" },
                { "toSQLFileToolStripMenuItem", "Para arquivo SQL" },
                { "toMPQToolStripMenuItem", "Para arquivo MPQ" },
                { "toJSONToolStripMenuItem", "Para arquivo JSON" },
                { "editDefinitionsToolStripMenuItem", "Editor de Definições" },
                { "wotLKItemFixToolStripMenuItem", "Importar Itens (WotLK)" },
                { "legionToolStripMenuItem", "Parser do Legion" },
                { "playerLocationRecorderToolStripMenuItem", "Gravador de Localização" },
                { "colourPickerToolStripMenuItem", "Seletor de Cores" },
                { "btnReset", "Redefinir" },
                { "gbSettings", "Estatísticas" },
                { "label7", "Filtro" },
                { "label6", "Build" },
                { "label1", "Arquivo Atual:" },
                { "label2", "Definição:" },
                { "label4", "Célula Atual:" },
                { "label5", "Estatísticas:" },
                { "aboutToolStripMenuItem", "Sobre..." },
                { "label8", "Modo de colunas:" },
                { "label3", "Colunas:" },
                { "msgAcoplarArchivosCuerpo", "Deseja acoplar os arquivos a esta janela?\n\n SIM = Acoplar na aba\n NÃO = Abrir em nova janela" },
                { "msgAcoplarArchivosTitulo", "Acoplar arquivo(s) DBC" },
                { "msgCambiosSinGuardarCuerpo", "Você tem alterações não salvas. Deseja sair?" },
                { "msgCambiosSinGuardarTitulo", "Alterações não salvas" },
            }},

            { "ru", new Dictionary<string, string> {
                { "fileToolStripMenuItem", "Файл" },
                { "editToolStripMenuItem", "Редактировать" },
                { "optionsToolStripMenuItem", "Инструменты" },
                { "exportToolStripMenuItem", "Экспорт" },
                { "importToolStripMenuItem", "Импорт" },
                { "helpToolStripMenuItem", "Настройки" },
                { "idiomaToolStripMenuItem", "Язык" },
                { "loadFilesToolStripMenuItem", "Загрузить файлы..." },
                { "recentToolStripMenuItem", "Последние файлы" },
                { "openFromMPQToolStripMenuItem", "Открыть из MPQ..." },
                { "openFromCASCToolStripMenuItem", "Открыть из CASC..." },
                { "saveToolStripMenuItem", "Сохранить" },
                { "saveAsToolStripMenuItem", "Сохранить как..." },
                { "saveAllToolStripMenuItem", "Сохранить все" },
                { "reloadToolStripMenuItem", "Перезагрузить" },
                { "closeToolStripMenuItem", "Закрыть" },
                { "closeAllToolStripMenuItem", "Закрыть все" },
                { "undoToolStripMenuItem", "Отменить" },
                { "redoToolStripMenuItem", "Повторить" },
                { "insertLineToolStripMenuItem", "Вставить строку" },
                { "insertToolStripMenuItem", "Вставить строку" },
                { "newLineToolStripMenuItem", "Новая строка" },
                { "findToolStripMenuItem", "Найти..." },
                { "replaceToolStripMenuItem", "Заменить..." },
                { "goToToolStripMenuItem", "Перейти к..." },
                { "fromCSVToolStripMenuItem", "Из CSV файла" },
                { "fromSQLToolStripMenuItem", "Из SQL сервера" },
                { "toCSVToolStripMenuItem", "В CSV файл" },
                { "toSQLToolStripMenuItem", "В SQL таблицу" },
                { "toSQLFileToolStripMenuItem", "В SQL файл" },
                { "toMPQToolStripMenuItem", "В MPQ файл" },
                { "toJSONToolStripMenuItem", "В JSON файл" },
                { "editDefinitionsToolStripMenuItem", "Редактор определений" },
                { "wotLKItemFixToolStripMenuItem", "Импорт предметов (WotLK)" },
                { "legionToolStripMenuItem", "Парсер Legion" },
                { "playerLocationRecorderToolStripMenuItem", "Запись позиции игрока" },
                { "colourPickerToolStripMenuItem", "Выбор цвета" },
                { "btnReset", "Сброс" },
                { "gbSettings", "Статистика" },
                { "label7", "Фильтр" },
                { "label6", "Сборка (Build)" },
                { "label1", "Текущий файл:" },
                { "label2", "Определение:" },
                { "label4", "Текущая ячейка:" },
                { "label5", "Статистика:" },
                { "aboutToolStripMenuItem", "О программе..." },
                { "label8", "Режим колонок:" },
                { "label3", "Колонки:" },
                { "msgAcoplarArchivosCuerpo", "Вы хотите прикрепить файлы к этому окну?\n\n ДА = Прикрепить во вкладке\n НЕТ = Открыть в новом окне" },
                { "msgAcoplarArchivosTitulo", "Прикрепить файл(ы) DBC" },
                { "msgCambiosSinGuardarCuerpo", "У вас есть несохраненные изменения. Вы хотите выйти?" },
                { "msgCambiosSinGuardarTitulo", "Несохраненные изменения" },
            }},

            { "fr", new Dictionary<string, string> {
                { "fileToolStripMenuItem", "Fichier" },
                { "editToolStripMenuItem", "Éditer" },
                { "optionsToolStripMenuItem", "Outils" },
                { "exportToolStripMenuItem", "Exporter" },
                { "importToolStripMenuItem", "Importer" },
                { "helpToolStripMenuItem", "Paramètres" },
                { "idiomaToolStripMenuItem", "Langue" },
                { "loadFilesToolStripMenuItem", "Charger des Fichiers..." },
                { "recentToolStripMenuItem", "Fichiers Récents" },
                { "openFromMPQToolStripMenuItem", "Ouvrir depuis MPQ..." },
                { "openFromCASCToolStripMenuItem", "Ouvrir depuis CASC..." },
                { "saveToolStripMenuItem", "Enregistrer" },
                { "saveAsToolStripMenuItem", "Enregistrer sous..." },
                { "saveAllToolStripMenuItem", "Tout Enregistrer" },
                { "reloadToolStripMenuItem", "Recharger" },
                { "closeToolStripMenuItem", "Fermer" },
                { "closeAllToolStripMenuItem", "Tout Fermer" },
                { "undoToolStripMenuItem", "Annuler" },
                { "redoToolStripMenuItem", "Rétablir" },
                { "insertLineToolStripMenuItem", "Insérer une Ligne" },
                { "insertToolStripMenuItem", "Insérer une Ligne" },
                { "newLineToolStripMenuItem", "Nouvelle Ligne" },
                { "findToolStripMenuItem", "Trouver..." },
                { "replaceToolStripMenuItem", "Remplacer..." },
                { "goToToolStripMenuItem", "Aller à..." },
                { "fromCSVToolStripMenuItem", "Depuis un fichier CSV" },
                { "fromSQLToolStripMenuItem", "Depuis un serveur SQL" },
                { "toCSVToolStripMenuItem", "Vers un fichier CSV" },
                { "toSQLToolStripMenuItem", "Vers une table SQL" },
                { "toSQLFileToolStripMenuItem", "Vers un fichier SQL" },
                { "toMPQToolStripMenuItem", "Vers un fichier MPQ" },
                { "toJSONToolStripMenuItem", "Vers un fichier JSON" },
                { "editDefinitionsToolStripMenuItem", "Éditeur de Définitions" },
                { "wotLKItemFixToolStripMenuItem", "Importer Objets (WotLK)" },
                { "legionToolStripMenuItem", "Analyseur Legion" },
                { "playerLocationRecorderToolStripMenuItem", "Enregistreur de Position" },
                { "colourPickerToolStripMenuItem", "Sélecteur de Couleurs" },
                { "btnReset", "Réinitialiser" },
                { "gbSettings", "Statistiques" },
                { "label7", "Filtre" },
                { "label6", "Build" },
                { "label1", "Fichier Actuel :" },
                { "label2", "Définition :" },
                { "label4", "Cellule Actuelle :" },
                { "label5", "Statistiques :" },
                { "aboutToolStripMenuItem", "À propos..." },
                { "label8", "Mode de colonnes :" },
                { "label3", "Colonnes :" },
                { "msgAcoplarArchivosCuerpo", "Voulez-vous ancrer les fichiers à cette fenêtre ?\n\n OUI = Ancrer dans l'onglet\n NON = Ouvrir dans une nouvelle fenêtre" },
                { "msgAcoplarArchivosTitulo", "Ancrer fichier(s) DBC" },
                { "msgCambiosSinGuardarCuerpo", "Vous avez des modifications non enregistrées. Voulez-vous quitter ?" },
                { "msgCambiosSinGuardarTitulo", "Modifications non enregistrées" },
            }},

            { "zh", new Dictionary<string, string> {
                { "fileToolStripMenuItem", "文件" },
                { "editToolStripMenuItem", "编辑" },
                { "optionsToolStripMenuItem", "工具" },
                { "exportToolStripMenuItem", "导出" },
                { "importToolStripMenuItem", "导入" },
                { "helpToolStripMenuItem", "设置" },
                { "idiomaToolStripMenuItem", "语言" },
                { "loadFilesToolStripMenuItem", "加载文件..." },
                { "recentToolStripMenuItem", "最近的文件" },
                { "openFromMPQToolStripMenuItem", "从MPQ打开..." },
                { "openFromCASCToolStripMenuItem", "从CASC打开..." },
                { "saveToolStripMenuItem", "保存" },
                { "saveAsToolStripMenuItem", "另存为..." },
                { "saveAllToolStripMenuItem", "保存全部" },
                { "reloadToolStripMenuItem", "重新加载" },
                { "closeToolStripMenuItem", "关闭" },
                { "closeAllToolStripMenuItem", "关闭全部" },
                { "undoToolStripMenuItem", "撤销" },
                { "redoToolStripMenuItem", "重做" },
                { "insertLineToolStripMenuItem", "插入行" },
                { "insertToolStripMenuItem", "插入行" },
                { "newLineToolStripMenuItem", "新建行" },
                { "findToolStripMenuItem", "查找..." },
                { "replaceToolStripMenuItem", "替换..." },
                { "goToToolStripMenuItem", "跳转到..." },
                { "fromCSVToolStripMenuItem", "从CSV文件" },
                { "fromSQLToolStripMenuItem", "从SQL服务器" },
                { "toCSVToolStripMenuItem", "导出为CSV文件" },
                { "toSQLToolStripMenuItem", "导出到SQL表" },
                { "toSQLFileToolStripMenuItem", "导出为SQL文件" },
                { "toMPQToolStripMenuItem", "导出为MPQ文件" },
                { "toJSONToolStripMenuItem", "导出为JSON文件" },
                { "editDefinitionsToolStripMenuItem", "定义编辑器" },
                { "wotLKItemFixToolStripMenuItem", "导入物品 (WotLK)" },
                { "legionToolStripMenuItem", "Legion解析器" },
                { "playerLocationRecorderToolStripMenuItem", "玩家位置记录器" },
                { "colourPickerToolStripMenuItem", "颜色选择器" },
                { "btnReset", "重置" },
                { "gbSettings", "统计信息" },
                { "label7", "过滤器" },
                { "label6", "版本 (Build)" },
                { "label1", "当前文件:" },
                { "label2", "定义:" },
                { "label4", "当前单元格:" },
                { "label5", "统计信息:" },
                { "aboutToolStripMenuItem", "关于..." },
                { "label8", "列模式:" },
                { "label3", "列:" },
                { "msgAcoplarArchivosCuerpo", "您想将文件停靠到此窗口吗？\n\n 是 = 停靠在选项卡中\n 否 = 在新窗口中打开" },
                { "msgAcoplarArchivosTitulo", "停靠 DBC 文件" },
                { "msgCambiosSinGuardarCuerpo", "您有未保存的更改。您想退出吗？" },
                { "msgCambiosSinGuardarTitulo", "未保存的更改" },
            }},
            { "de", new Dictionary<string, string> {
                // Menús Principales
                { "fileToolStripMenuItem", "Datei" },
                { "editToolStripMenuItem", "Bearbeiten" },
                { "optionsToolStripMenuItem", "Werkzeuge" },
                { "exportToolStripMenuItem", "Exportieren" },
                { "importToolStripMenuItem", "Importieren" },
                { "helpToolStripMenuItem", "Einstellunge" },
                { "idiomaToolStripMenuItem", "Sprache" },

                // Sub-menús de Archivo
                { "loadFilesToolStripMenuItem", "Dateien laden..." },
                { "recentToolStripMenuItem", "Letzte Dateien" },
                { "openFromMPQToolStripMenuItem", "Aus MPQ öffnen..." },
                { "openFromCASCToolStripMenuItem", "Aus CASC öffnen..." },
                { "saveToolStripMenuItem", "Speichern" },
                { "saveAsToolStripMenuItem", "Speichern unter..." },
                { "saveAllToolStripMenuItem", "Alle speichern" },
                { "reloadToolStripMenuItem", "Neu laden" },
                { "closeToolStripMenuItem", "Schließen" },
                { "closeAllToolStripMenuItem", "Alle schließen" },

                // Sub-menús de Editar
                { "undoToolStripMenuItem", "Rückgängig" },
                { "redoToolStripMenuItem", "Wiederholen" },
                { "insertLineToolStripMenuItem", "Zeile einfügen" },
                { "insertToolStripMenuItem", "Zeile einfügen" },
                { "newLineToolStripMenuItem", "Neue Zeile" },
                { "findToolStripMenuItem", "Suchen..." },
                { "replaceToolStripMenuItem", "Ersetzen..." },
                { "goToToolStripMenuItem", "Gehe zu..." },

                // Sub-menús de Importar/Exportar
                { "fromCSVToolStripMenuItem", "Aus CSV-Datei" },
                { "fromSQLToolStripMenuItem", "Vom SQL-Server" },
                { "toCSVToolStripMenuItem", "In CSV-Datei" },
                { "toSQLToolStripMenuItem", "In SQL-Tabelle" },
                { "toSQLFileToolStripMenuItem", "In SQL-Datei" },
                { "toMPQToolStripMenuItem", "In MPQ-Datei" },
                { "toJSONToolStripMenuItem", "In JSON-Datei" },

                // Herramientas
                { "editDefinitionsToolStripMenuItem", "Definitionseditor" },
                { "wotLKItemFixToolStripMenuItem", "(WotLK) Item-Import" },
                { "legionToolStripMenuItem", "Legion-Parser" },
                { "playerLocationRecorderToolStripMenuItem", "Spielerposition-Rekorder" },
                { "colourPickerToolStripMenuItem", "Farbwähler" },
                
                // Etiquetas de la interfaz visual y Botones
                { "btnReset", "Zurücksetzen" },
                { "gbSettings", "Statistiken" }, 
                
                // Nombres genéricos
                { "label7", "Filter" },
                { "label6", "Build" },
                { "label1", "Aktuelle Datei:" },
                { "label2", "Definition:" },
                { "label4", "Aktuelle Zelle:" },
                { "label5", "Statistiken:" },

                // Otros
                { "aboutToolStripMenuItem", "Über..." },
                // Textos de Columnas
                { "label8", "Spaltenmodus:" },
                { "label3", "Spalten:" },
                { "msgAcoplarArchivosCuerpo", "Möchten Sie die Dateien an dieses Fenster andocken?\n\n JA = Im Tab andocken\n NEIN = In neuem Fenster öffnen" },
                { "msgAcoplarArchivosTitulo", "DBC-Datei(en) andocken" },
                { "msgCambiosSinGuardarCuerpo", "Sie haben ungespeicherte Änderungen. Möchten Sie beenden?" },
                { "msgCambiosSinGuardarTitulo", "Ungespeicherte Änderungen" },
            }},

            { "ko", new Dictionary<string, string> {
                // Menús Principales
                { "fileToolStripMenuItem", "파일" },
                { "editToolStripMenuItem", "편집" },
                { "optionsToolStripMenuItem", "도구" },
                { "exportToolStripMenuItem", "내보내기" },
                { "importToolStripMenuItem", "가져오기" },
                { "helpToolStripMenuItem", "설정" },
                { "idiomaToolStripMenuItem", "언어" },

                // Sub-menús de Archivo
                { "loadFilesToolStripMenuItem", "파일 불러오기..." },
                { "recentToolStripMenuItem", "최근 파일" },
                { "openFromMPQToolStripMenuItem", "MPQ에서 열기..." },
                { "openFromCASCToolStripMenuItem", "CASC에서 열기..." },
                { "saveToolStripMenuItem", "저장" },
                { "saveAsToolStripMenuItem", "다른 이름으로 저장..." },
                { "saveAllToolStripMenuItem", "모두 저장" },
                { "reloadToolStripMenuItem", "새로 고침" },
                { "closeToolStripMenuItem", "닫기" },
                { "closeAllToolStripMenuItem", "모두 닫기" },

                // Sub-menús de Editar
                { "undoToolStripMenuItem", "실행 취소" },
                { "redoToolStripMenuItem", "다시 실행" },
                { "insertLineToolStripMenuItem", "줄 삽입" },
                { "insertToolStripMenuItem", "줄 삽입" },
                { "newLineToolStripMenuItem", "새 줄" },
                { "findToolStripMenuItem", "찾기..." },
                { "replaceToolStripMenuItem", "바꾸기..." },
                { "goToToolStripMenuItem", "이동..." },

                // Sub-menús de Importar/Exportar
                { "fromCSVToolStripMenuItem", "CSV 파일에서" },
                { "fromSQLToolStripMenuItem", "SQL 서버에서" },
                { "toCSVToolStripMenuItem", "CSV 파일로" },
                { "toSQLToolStripMenuItem", "SQL 테이블로" },
                { "toSQLFileToolStripMenuItem", "SQL 파일로" },
                { "toMPQToolStripMenuItem", "MPQ 파일로" },
                { "toJSONToolStripMenuItem", "JSON 파일로" },

                // Herramientas
                { "editDefinitionsToolStripMenuItem", "정의 편집기" },
                { "wotLKItemFixToolStripMenuItem", "(WotLK) 아이템 가져오기" },
                { "legionToolStripMenuItem", "군단 파서" },
                { "playerLocationRecorderToolStripMenuItem", "플레이어 위치 기록기" },
                { "colourPickerToolStripMenuItem", "색상 선택기" },
                
                // Etiquetas de la interfaz visual y Botones
                { "btnReset", "초기화" },
                { "gbSettings", "통계" }, 
                
                // Nombres genéricos
                { "label7", "필터" },
                { "label6", "빌드 (Build)" },
                { "label1", "현재 파일:" },
                { "label2", "정의:" },
                { "label4", "현재 셀:" },
                { "label5", "통계:" },

                // Otros
                { "aboutToolStripMenuItem", "정보..." },
                { "msgAcoplarArchivosCuerpo", "파일을 이 창에 도킹하시겠습니까?\n\n 예 = 탭에 도킹\n 아니요 = 새 창에서 열기" },
                { "msgAcoplarArchivosTitulo", "DBC 파일 도킹" },
                { "msgCambiosSinGuardarCuerpo", "저장하지 않은 변경 사항이 있습니다. 종료하시겠습니까?" },
                { "msgCambiosSinGuardarTitulo", "저장하지 않은 변경 사항" },
                // Textos de Columnas
                { "label8", "열 모드:" },
                { "label3", "열:" },
            }}
        };

        // 2. CONSTRUCTOR ESTÁTICO: Aquí ocurre la magia de la detección automática
        static LanguageManager()
        {
            // 1. Leer lo que el usuario guardó la última vez
            string idiomaGuardado = Properties.Settings.Default.Idioma;

            // 2. Si hay un idioma guardado y existe en nuestro diccionario, lo usamos
            if (!string.IsNullOrEmpty(idiomaGuardado) && TRANSLATIONS.ContainsKey(idiomaGuardado))
            {
                IdiomaActual = idiomaGuardado;
            }
            else
            {
                // 3. Si es la primera vez (está vacío), detectamos el idioma de Windows
                string idiomaSO = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
                IdiomaActual = TRANSLATIONS.ContainsKey(idiomaSO) ? idiomaSO : "en";
            }
        }
                
        // 3. Método para que el usuario cambie de idioma manualmente si lo desea
        // MÉTODO CAMBIAR IDIOMA: Aplica la traducción y guarda la preferencia
        public static void CambiarIdioma(string langCode, Form formActual)
        {
            IdiomaActual = langCode;

            // Guardamos el nuevo idioma en la configuración de la PC del usuario
            Properties.Settings.Default.Idioma = langCode;
            Properties.Settings.Default.Save();

            TraducirControles(formActual);
        }

        // 4. Método que aplica los textos al formulario
        public static void TraducirControles(Control control)
        {
            // TryGetValue busca el idioma y, si lo encuentra, lo guarda directamente en "dict".
            // Si no lo encuentra, devuelve false y sale del método con el return.
            if (!TRANSLATIONS.TryGetValue(IdiomaActual, out var dict)) return;

            AplicarTraduccion(control, dict);
        }

        // MÉTODO NUEVO: Obtener la traducción de un texto específico
        public static string ObtenerTexto(string clave, string textoPorDefecto = "")
        {
            // Intentamos obtener el diccionario del idioma actual
            if (TRANSLATIONS.TryGetValue(IdiomaActual, out var dict))
            {
                // Si la clave existe en el idioma actual, devolvemos su valor
                if (dict.TryGetValue(clave, out string textoTraducido))
                {
                    return textoTraducido;
                }
            }

            // Si no encontramos la traducción o el idioma, devolvemos el texto por defecto
            // Si no se proporcionó un texto por defecto, devolvemos la misma clave para que el desarrollador note que falta la traducción.
            return string.IsNullOrEmpty(textoPorDefecto) ? clave : textoPorDefecto;
        }

        // Métodos internos de traducción
        private static void AplicarTraduccion(Control control, Dictionary<string, string> dict)
        {
            if (dict.TryGetValue(control.Name, out string text)) control.Text = text;
            foreach (Control c in control.Controls) AplicarTraduccion(c, dict);
            if (control is MenuStrip ms) foreach (ToolStripItem item in ms.Items) TraducirMenu(item, dict);
        }

        private static void TraducirMenu(ToolStripItem item, Dictionary<string, string> dict)
        {
            if (dict.TryGetValue(item.Name, out string text)) item.Text = text;
            if (item is ToolStripMenuItem m) foreach (ToolStripItem sub in m.DropDownItems) TraducirMenu(sub, dict);
        }
    }
}