namespace ConsolePw
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;

    class Program
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hObject);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);




        const uint PROCESS_VM_READ = 0x0010;
        const uint PROCESS_QUERY_INFORMATION = 0x0400;

        const uint WM_KEYDOWN = 0x0100;
        const uint WM_KEYUP = 0x0101;

        static int GetProcessIdByName(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                return process.Id;
            }
            return 0;
        }

        static string ReadMemory(IntPtr hProcess, IntPtr baseAddress, uint size)
        {
            byte[] buffer = new byte[size];
            if (ReadProcessMemory(hProcess, baseAddress, buffer, size, out IntPtr bytesRead))
            {
                return Encoding.ASCII.GetString(buffer);
            }
            return string.Empty;
        }

        static int ReadIntFromMemory(IntPtr hProcess, IntPtr baseAddress, uint size)
        {
            byte[] buffer = new byte[size];
            if (ReadProcessMemory(hProcess, baseAddress, buffer, size, out IntPtr bytesRead))
            {
                if (bytesRead.ToInt32() == size)
                {
                    return BitConverter.ToInt32(buffer, 0); // Преобразуем 4 байта в int
                }
            }
            return 0; // Возвращаем 0, если чтение не удалось
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите базовый адрес (в 16-ричном формате, например, 0x12345678):");
            string input = Console.ReadLine();

            if (!ulong.TryParse(input, System.Globalization.NumberStyles.HexNumber, null, out ulong baseAddressHex))
            {
                Console.WriteLine("Неверный формат адреса.");
                return;
            }

            IntPtr baseAddress = (IntPtr)baseAddressHex;

            // Получаем PID процесса elementclient.exe
            int processId = GetProcessIdByName("ElementClient");
            if (processId == 0)
            {
                Console.WriteLine("Процесс elementclient.exe не найден.");
                return;
            }

            // Открываем процесс
            IntPtr hProcess = OpenProcess(PROCESS_VM_READ | PROCESS_QUERY_INFORMATION, false, processId);
            if (hProcess == IntPtr.Zero)
            {
                Console.WriteLine("Не удалось открыть процесс.");
                return;
            }

            try
            {
                // Эмуляция логики для чтения данных из памяти
                List<DataAddr> dataArray = GetMockData(); // Замените на реальную логику

                foreach (var data in dataArray)
                {
                    IntPtr address = baseAddress + Convert.ToInt32(data.Offset, 16);
                    //string value = ReadMemory(hProcess, address, 4); // Читаем 4 байта
                    int value = ReadIntFromMemory(hProcess, address, 4); // Читаем 4 байта как int

                    data.Value = value.ToString();

                    Console.WriteLine($"{data.Id}) {data.Name} - {data.Comments} (смещение: {data.Offset}, значение: {data.Value})");
                }


                
                // Найти окно клиента
                IntPtr hWnd = FindWindow(null, "Comeback"); // Укажите точное имя окна
                if (hWnd == IntPtr.Zero)
                {
                    Console.WriteLine("Окно не найдено.");
                    return;
                }

        
                const int VK_1 = 0x31; // Виртуальный код для клавиши '1'
                const int VK_0 = 0x30; // Клавиша '0'
                const int VK_2 = 0x32; // Клавиша '2'
                const int VK_3 = 0x33; // Клавиша '3'
                const int VK_4 = 0x34; // Клавиша '4'
                const int VK_5 = 0x35; // Клавиша '5'
                const int VK_6 = 0x36; // Клавиша '6'
                const int VK_7 = 0x37; // Клавиша '7'
                const int VK_8 = 0x38; // Клавиша '8'
                const int VK_9 = 0x39; // Клавиша '9'
                const int VK_F1 = 0x70; // Клавиша F1
                const int VK_F2 = 0x71; // Клавиша F2
                const int VK_F3 = 0x72; // Клавиша F3
                const int VK_F4 = 0x73; // Клавиша F4
                const int VK_F5 = 0x74; // Клавиша F5
                const int VK_F6 = 0x75; // Клавиша F6
                const int VK_F7 = 0x76; // Клавиша F7
                const int VK_F8 = 0x77; // Клавиша F8
                const int VK_F9 = 0x78; // Клавиша F9
                const int VK_F10 = 0x79; // Клавиша F10
                const int VK_F11 = 0x7A; // Клавиша F11
                const int VK_F12 = 0x7B; // Клавиша F12
                const int VK_W = 0x57; // Клавиша 'W'
                const int VK_A = 0x41; // Клавиша 'A'
                const int VK_S = 0x53; // Клавиша 'S'
                const int VK_D = 0x44; // Клавиша 'D'
                const int VK_X = 0x58; // Клавиша 'X'
                const int VK_TAB = 0x09; // Клавиша 'Tab'


                /*
                while (true)
                {
                    PostMessage(hWnd, WM_KEYDOWN, (IntPtr)VK_TAB, IntPtr.Zero);
                    Thread.Sleep(200); // Задержка в миллисекундах
                    PostMessage(hWnd, WM_KEYUP, (IntPtr)VK_TAB, IntPtr.Zero);
                    Thread.Sleep(500); // Задержка в миллисекундах
                    PostMessage(hWnd, WM_KEYDOWN, (IntPtr)VK_1, IntPtr.Zero);
                    Thread.Sleep(200); // Задержка в миллисекундах
                    PostMessage(hWnd, WM_KEYUP, (IntPtr)VK_1, IntPtr.Zero);

                    Thread.Sleep(15000); // Задержка в миллисекундах
                }
                */

            }
            finally
            {
                CloseHandle(hProcess);
            }
        }

        static List<DataAddr> GetMockData()
        {
            // Здесь вы можете вернуть тестовые данные или загрузить их из вашей логики
            return new List<DataAddr>
            {
                new DataAddr { Id = "1", Name = "lifeNow", Comments = "Жизни сейчас", Offset = "0x0", Len = "dword" },
                new DataAddr { Id = "2", Name = "manaNow", Comments = "Манна сейчас", Offset = "0x4", Len = "dword" },
                new DataAddr { Id = "3", Name = "expNow", Comments = "Текущий опыт", Offset = "0x8", Len = "dword" },
                new DataAddr { Id = "4", Name = "spirit", Comments = "Дух", Offset = "0xC", Len = "dword" },
                new DataAddr { Id = "5", Name = "skillPoints", Comments = "Доступно очков для распределения", Offset = "0x10", Len = "dword" },
                new DataAddr { Id = "6", Name = "chiPoints", Comments = "Единицы ярости", Offset = "0x14", Len = "dword" },
                new DataAddr { Id = "7", Name = "pA", Comments = "Параметр атаки", Offset = "0x18", Len = "dword" },
                new DataAddr { Id = "8", Name = "pZ", Comments = "Параметр защиты", Offset = "0x1C", Len = "dword" },
                new DataAddr { Id = "9", Name = "krit", Comments = "Шанс крита", Offset = "0x20", Len = "dword" },
                new DataAddr { Id = "10", Name = "vitality", Comments = "Выносливость", Offset = "0x54", Len = "dword" },
                new DataAddr { Id = "11", Name = "intellect", Comments = "Интелект", Offset = "0x58", Len = "dword" },
                new DataAddr { Id = "12", Name = "strength", Comments = "Сила", Offset = "0x5C", Len = "dword" },
                new DataAddr { Id = "13", Name = "dexterity", Comments = "Ловкость", Offset = "0x60", Len = "dword" },
                new DataAddr { Id = "14", Name = "maxHp", Comments = "Максимальные жизни", Offset = "0x64", Len = "dword" },
                new DataAddr { Id = "15", Name = "maxMp", Comments = "Максимальная манна", Offset = "0x68", Len = "dword" },
                new DataAddr { Id = "16", Name = "metkost", Comments = "Меткость", Offset = "0x84", Len = "dword" },
                new DataAddr { Id = "17", Name = "minPhyzAtk", Comments = "Мин физ. Атака", Offset = "0x88", Len = "dword" },
                new DataAddr { Id = "18", Name = "maxPhyzAtk", Comments = "Максимальная физ. Атака", Offset = "0x8C", Len = "dword" },
                new DataAddr { Id = "19", Name = "maxMagAtk", Comments = "Максимальная маг. Атака", Offset = "0xC4", Len = "dword" },
                new DataAddr { Id = "20", Name = "minMagAtk", Comments = "Мин маг. Атака", Offset = "0xC0", Len = "dword" },
                new DataAddr { Id = "21", Name = "defMetal", Comments = "Защита метал", Offset = "0xC8", Len = "dword" },
                new DataAddr { Id = "22", Name = "defWood", Comments = "Защита дерево", Offset = "0xCC", Len = "dword" },
                new DataAddr { Id = "23", Name = "defWater", Comments = "Защита вода", Offset = "0xD0", Len = "dword" },
                new DataAddr { Id = "24", Name = "defFire", Comments = "Защита огонь", Offset = "0xD4", Len = "dword" },
                new DataAddr { Id = "25", Name = "defEarth", Comments = "Защита земля", Offset = "0xD8", Len = "dword" },
                new DataAddr { Id = "26", Name = "defPhyz", Comments = "Защита физическая", Offset = "0xDC", Len = "dword" },
                new DataAddr { Id = "27", Name = "flee", Comments = "Уклонение", Offset = "0xE0", Len = "dword" },
                new DataAddr { Id = "28", Name = "maxFury", Comments = "Максимальная ярость", Offset = "0xE4", Len = "dword" },
                new DataAddr { Id = "29", Name = "money", Comments = "Деньги", Offset = "0xEC", Len = "dword" },
                new DataAddr { Id = "30", Name = "maxMoney", Comments = "Максимальные деньги", Offset = "0xF0", Len = "dword" },
                new DataAddr { Id = "31", Name = "equipWeapon", Comments = "Одетое оружие", Offset = "0xF4", Len = "word" },
                new DataAddr { Id = "32", Name = "equipHelmet", Comments = "Одетый шлем", Offset = "0xF8", Len = "word" },
                new DataAddr { Id = "33", Name = "equipNecklace", Comments = "Одетое ожерелье", Offset = "0xFC", Len = "word" },
                new DataAddr { Id = "34", Name = "equipManteau", Comments = "Одетая мантия", Offset = "0x100", Len = "word" },
                new DataAddr { Id = "35", Name = "equipShirt", Comments = "Одетая рубашка", Offset = "0x104", Len = "word" },
                new DataAddr { Id = "36", Name = "equipWaistAdorn", Comments = "Одетый пояс", Offset = "0x108", Len = "word" },
                new DataAddr { Id = "37", Name = "equipFootwear", Comments = "Одетые поножи", Offset = "0x10C", Len = "word" },
                new DataAddr { Id = "38", Name = "equipBoots", Comments = "Одетая обувь", Offset = "0x110", Len = "word" },
                new DataAddr { Id = "39", Name = "equipWristBracer", Comments = "Одетые наручи", Offset = "0x114", Len = "word" },
                new DataAddr { Id = "40", Name = "equipRing1", Comments = "Левое кольцо", Offset = "0x118", Len = "word" },
                new DataAddr { Id = "41", Name = "equipRing2", Comments = "Правое кольцо", Offset = "0x11C", Len = "word" },
                new DataAddr { Id = "42", Name = "equipProjectile", Comments = "Стрелы", Offset = "0x120", Len = "word" },
                new DataAddr { Id = "43", Name = "equipFly", Comments = "Полет", Offset = "0x124", Len = "word" },
                new DataAddr { Id = "44", Name = "equipBodyFashion", Comments = "Стиль обувь", Offset = "0x128", Len = "word" },
                new DataAddr { Id = "45", Name = "equipLegwearFashion", Comments = "Стиль штаны", Offset = "0x12C", Len = "word" },
                new DataAddr { Id = "46", Name = "equipSpecialFootwears", Comments = "Стиль специальная обувь", Offset = "0x130", Len = "word" },
                new DataAddr { Id = "47", Name = "equipArmFashion", Comments = "Стиль армейская модная одежда", Offset = "0x134", Len = "word" },
                new DataAddr { Id = "48", Name = "equipHead", Comments = "Стиль головы", Offset = "0x138", Len = "word" },
                new DataAddr { Id = "49", Name = "equipPigment", Comments = "Одетый пигмент", Offset = "0x13C", Len = "word" },
                new DataAddr { Id = "50", Name = "equipSmiley", Comments = "Одетые смайлы", Offset = "0x140", Len = "word" },
                new DataAddr { Id = "51", Name = "equip", Comments = "Одетая хирка на ХП", Offset = "0x144", Len = "word" },
                new DataAddr { Id = "52", Name = "equipSpiritCharm", Comments = "Одетая хирка на ману", Offset = "0x148", Len = "word" },
                new DataAddr { Id = "53", Name = "reputation", Comments = "Репутация", Offset = "0x198", Len = "dword" },
                new DataAddr { Id = "54", Name = "clanID", Comments = "Ид клана", Offset = "0x1D4", Len = "dword" },
                new DataAddr { Id = "55", Name = "clanPost", Comments = "Должность в клане - 6 - рядовой 5 - капитан 4 - майор 3 - маршал 2 - мастер", Offset = "0x1D8", Len = "dword" },
                new DataAddr { Id = "56", Name = "activePetId", Comments = "ID призванного ездового пета. =0 если не призван", Offset = "0x1DC", Len = "byte" },
                new DataAddr { Id = "57", Name = "classID", Comments = "ID Класса - Значение: 0-воин 1-маг 2-шаман 3-друид 4-оборотень 5-убийца 6-лучник 7-жрец 8-страж 9-мистик", Offset = "0x22C", Len = "byte" },
                new DataAddr { Id = "58", Name = "gender", Comments = "ID пола - Значение: 0 - Мужчина, 1 - Женщина", Offset = "0x230", Len = "byte" },
                new DataAddr { Id = "59", Name = "walkMode", Comments = "Позиция: 0 - Земля, 1 - Вода, 2 - Воздух", Offset = "0x238", Len = "byte" },
                new DataAddr { Id = "60", Name = "runMode", Comments = "Значение: 0 - стоит, 1 - бег - кнопка бежать, стоять", Offset = "0x23C", Len = "byte" },
                new DataAddr { Id = "61", Name = "meditation", Comments = "Значение: 0 - Walking, 10 - Flying, 20 - Meditation (20 именно в байт коде)", Offset = "0x2B4", Len = "byte" },
                new DataAddr { Id = "62", Name = "coord1_1", Comments = "Координата1_1", Offset = "0x280", Len = "dword" },
                new DataAddr { Id = "63", Name = "coord1_2", Comments = "Координата1_2", Offset = "0x2B0", Len = "dword" },
                new DataAddr { Id = "64", Name = "coord2_1", Comments = "Координата2_1", Offset = "0x270", Len = "dword" },
                new DataAddr { Id = "65", Name = "coord2_2", Comments = "Координата2_2", Offset = "0x2A0", Len = "dword" },
                new DataAddr { Id = "66", Name = "coord3_1", Comments = "Координата3_1", Offset = "0x27C", Len = "dword" },
                new DataAddr { Id = "67", Name = "coord3_2", Comments = "Координата3_2", Offset = "0x2AC", Len = "dword" },
                new DataAddr { Id = "68", Name = "camera1", Comments = "Камера1", Offset = "0x2EC", Len = "dword" },
                new DataAddr { Id = "69", Name = "camera2", Comments = "Камера2", Offset = "0x288", Len = "dword" },
                new DataAddr { Id = "70", Name = "camera3", Comments = "Камера3", Offset = "0x2E4", Len = "dword" },
                new DataAddr { Id = "71", Name = "camera4", Comments = "Камера4", Offset = "0x288", Len = "dword" },
                new DataAddr { Id = "72", Name = "waitSkill", Comments = "\"Использованный скил - 4 SkillID 8 SkillID C SkillLvl 10 SkillCoolDown 14 SkillMaxCoolDown\"", Offset = "0x320", Len = "dword" },
                new DataAddr { Id = "73", Name = "castID", Comments = "ИД скастованого заклинания", Offset = "0x324", Len = "dword" },
                new DataAddr { Id = "74", Name = "playerStatus", Comments = "Статус персонажа", Offset = "0xFFFFFFFC", Len = "dword" },
                new DataAddr { Id = "75", Name = "playerLvL", Comments = "Уровень персонажа", Offset = "0xFFFFFFF8", Len = "dword" },
                new DataAddr { Id = "76", Name = "buffsCnt1", Comments = "Количество бафов 1", Offset = "0xFFFFFFE0", Len = "dword" },
                new DataAddr { Id = "77", Name = "buffsCnt2", Comments = "Количество бафов 2", Offset = "0xFFFFFFDC", Len = "dword" },
                new DataAddr { Id = "78", Name = "buffsArray", Comments = "Список бафов", Offset = "0x12C", Len = "dword" }
            };
        }
    }

    class DataAddr
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public string Offset { get; set; }

        public string Len { get; set; }
        public string Value { get; set; }
    }

}
