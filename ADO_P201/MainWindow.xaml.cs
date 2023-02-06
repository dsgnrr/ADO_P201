﻿
using System.Windows;

using System.Data.SqlClient; // не забути про NuGet
using System.Windows.Media;
using System;

namespace ADO_P201
{
    public partial class MainWindow : Window
    {
        //об'єкт підключення: головний елемент ADO
        private SqlConnection _connection;
        public MainWindow()
        {
            InitializeComponent();
            //!! Створення об'єкта не відкриває підключення
            _connection = new SqlConnection();
            // Головний параметр підключення - рядок підключення
            _connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Seme_i7uf\Documents\GitHub\ADO_P201\ADO_P201\ADO201.mdf;Integrated Security=True";

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _connection.Open();
                StatusConnection.Content = "Connected";
                StatusConnection.Foreground = Brushes.Green;
            }
            catch (SqlException ex)
            {
                StatusConnection.Content = "Disconnected";
                StatusConnection.Foreground = Brushes.Green;
                MessageBox.Show(ex.Message);
                this.Close();
            }
            ShowMonitor();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            if (_connection?.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }

        #region Запити без повернення результатів

        private void installDepartments_Click(object sender, RoutedEventArgs e)
        {
            //Команда - інструмент для виконання SQL запитів
            SqlCommand cmd = new SqlCommand();
            //Головні параметри команди:
            cmd.Connection = _connection; //підключення (відкрите)
            cmd.CommandText = // SQL запит (текст)
                @"CREATE TABLE Departments(
	                Id			UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	                Name		NVARCHAR(50) NOT NULL
                )";

            try//виконання команди
            {
                cmd.ExecuteNonQuery(); // NonQuery - без повернення результату
                MessageBox.Show("Create OK");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd.Dispose(); // некерований ресурс, вимагає утилізації
        }


        private void insertlDepartments_Click(object sender, RoutedEventArgs e)
        {
            //Команда - інструмент для виконання SQL запитів
            SqlCommand cmd = new SqlCommand();
            //Головні параметри команди:
            cmd.Connection = _connection; //підключення (відкрите)
            cmd.CommandText = // SQL запит (текст)
                @"INSERT INTO Departments 
	                        ( Id, Name )
                VALUES 
	            ( 'D3C376E4-BCE3-4D85-ABA4-E3CF49612C94',  N'IT отдел'		 	 ), 
	            ( '131EF84B-F06E-494B-848F-BB4BC0604266',  N'Бухгалтерия'		 ), 
	            ( '8DCC3969-1D93-47A9-8B79-A30C738DB9B4',  N'Служба безопасности'), 
	            ( 'D2469412-0E4B-46F7-80EC-8C522364D099',  N'Отдел кадров'		 ),
	            ( '1EF7268C-43A8-488C-B761-90982B31DF4E',  N'Канцелярия'		 ), 
	            ( '415B36D9-2D82-4A92-A313-48312F8E18C6',  N'Отдел продаж'		 ), 
	            ( '624B3BB5-0F2C-42B6-A416-099AAB799546',  N'Юридическая служба' )";

            try//виконання команди
            {
                cmd.ExecuteNonQuery(); // NonQuery - без повернення результату
                MessageBox.Show("Insert OK");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            cmd.Dispose(); // некерований ресурс, вимагає утилізації
        }

        private void installProducts_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = @"
                CREATE TABLE Products (
                Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
                Name NVARCHAR(50) NOT NULL,
                Price FLOAT NOT NULL);";

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show(
                    "Products create",
                    "SQL complete",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "SQL error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void insertlProducts_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = @"INSERT INTO Products
	( Id, Name,	Price	)
VALUES
    ( 'DA1E17BB-A90D-4C79-B801-5462FB070F57', N'Гвоздь 100мм',			10.50	),
    ( 'A8E6BE17-5447-4804-AB61-F31ABF5A76D3', N'Шуруп 4х35',			4.25	),
    ( '21B0F444-2E4F-47D8-80C1-E69BF1C34CA8', N'Гайка М4',				6.50	),
    ( '2DCA5E44-B06D-4613-BB6A-D3BC91430BFE', N'Гровер М4',			    5.99	),
    ( '64A4DF8A-0733-4BE9-AABA-C01B4EC3612A', N'Болт 4х60',			    9.98	),
    ( 'B6D20749-B495-4B1A-BA1C-80B88E78B7CD', N'Гвоздь 80мм',			19.98	),
    ( '7B08197B-C55F-4389-891F-BF12A575DFFB', N'Отвертка PZ2',			35.50	),
    ( '870DA1A9-44F4-4018-B7FC-727A2058FAF0', N'Шуруповерт',			799		),
    ( '8FF90E21-DCDB-4D55-A557-7C6D57DBB029', N'Молоток',				216.50	),
    ( 'F7F1E576-AF8D-4749-869E-4A794FE69D42', N'Набор Новосел',		52.40	),
    ('BB29F63D-1261-41F2-89E8-88F44D5EC409', N'Сверло 6х80', 39.98),
    ('D17A4442-0A71-4673-B450-36929048ADEF', N'Шуруп 5х45',			5.98    ),
    ('69B125D7-99CC-42D6-A6FA-46687F333749', N'Винт потай 3х16',		3.98    ),
    ('94BC671A-A6B6-417A-BC9F-8AE4871A58EC', N'Дюбель 6х60',			5.50    ),
    ('EFC6578A-00B7-4766-A7E3-79CDBA8C294B', N'Органайзер для шурупов',199     ),
    ('9654271B-AB52-4225-A30C-D75054B1733F', N'Лазерный дальномер',	1950    ),
    ('F2585221-1ACA-4EFE-A5E8-C2F4534D1F92', N'Дрель электрическая',	990     ),
    ('4A550D3B-D1F2-40EF-AE4E-963612C6713A', N'Сварочный аппарат',		2099    ),
    ('17DB11D1-F50E-4CF4-9C54-CF1BD45802EA', N'Электроды 3мм',			49.98   ),
    ('7264D33A-16B9-4E22-B3F1-63D6DAE60078', N'Паяльник 40 Вт',		199.98  )";
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show(
                    "Products filled",
                    "SQL complete",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "SQL error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void installManagers_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = @"
                CREATE TABLE Products (
                Id UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
                Name NVARCHAR(50) NOT NULL,
                Price FLOAT NOT NULL);";

            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show(
                    "Managers create",
                    "SQL complete",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "SQL error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void insertlManagers_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = _connection;
            cmd.CommandText = @"";
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show(
                    "Managers filled",
                    "SQL complete",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "SQL error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        #endregion

        #region Скалярні запити - з одним результатом
        private void ShowMonitor()
        {
            ShowMonitorDepartments();
            ShowMonitorProducts();
            ShowMonitorManagers();
        }
        /// <summary>
        /// Відображає на моніторі кількість відділів (департементів) у БД
        /// </summary>
        private void ShowMonitorDepartments()
        {
            using SqlCommand cmd = new SqlCommand("select Count(*) from Departments", _connection);
            try
            {
                var res=cmd.ExecuteScalar(); //повертає "лівий-верхній" результат скаляру
                //тип повернення - object, оскільки результат може бути довільного типу
                //для використання результат бажано конвертувати до очікуваного типу
                int cnt = Convert.ToInt32(res);
                StatusDepartments.Content = cnt.ToString();
            }
            catch(SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "SQL error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                StatusDepartments.Content = "--";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Cast error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);

                StatusDepartments.Content = "--";
            }
        }
        private void ShowMonitorProducts()
        {
            using SqlCommand cmd = new SqlCommand("select Count(*) from Products", _connection);
            try
            {
                var res = cmd.ExecuteScalar(); //повертає "лівий-верхній" результат скаляру
                //тип повернення - object, оскільки результат може бути довільного типу
                //для використання результат бажано конвертувати до очікуваного типу
                int cnt = Convert.ToInt32(res);
                StatusProducts.Content = cnt.ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "SQL error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                StatusProducts.Content = "--";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Cast error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);

                StatusProducts.Content = "--";
            }
        }

        private void ShowMonitorManagers()
        {
            using SqlCommand cmd = new SqlCommand("select Count(*) from Managers", _connection);
            try
            {
                var res = cmd.ExecuteScalar(); //повертає "лівий-верхній" результат скаляру
                //тип повернення - object, оскільки результат може бути довільного типу
                //для використання результат бажано конвертувати до очікуваного типу
                int cnt = Convert.ToInt32(res);
                StatusProducts.Content = cnt.ToString();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "SQL error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);

                StatusProducts.Content = "--";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Cast error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Exclamation);

                StatusProducts.Content = "--";
            }
        }
        #endregion


    }
}
