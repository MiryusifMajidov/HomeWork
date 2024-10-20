namespace WeaponProject
{
    internal class Program
    {
        static Weapon[] weapons = new Weapon[0];

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool isTrue = true;

            while (isTrue)
            {
                Console.Clear();
                Console.WriteLine("Xoş gəlmisiniz!");
                Console.WriteLine("1. Silah əlavə et");
                Console.WriteLine("2. Silah seç");
                Console.WriteLine("3. Çıxış");
                Console.Write("Seçiminizi edin: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddNewWeapon();
                        break;
                    case "2":
                        ChooseWeapon();
                        break;
                    case "3": 
                        isTrue = false;
                        return;
                    default:
                        Console.WriteLine("Yanlış seçim etdiniz.");
                        break;
                }

                Console.WriteLine("Menyuya qayıtmaq üçün Enter düyməsini basın...");
                Console.ReadLine();
            }
        }

        static void ChooseWeapon()
        {
            Console.WriteLine("Mövcud olan silahlar bunlardır.");
            int startWeaponIndex = 0;

            if (weapons.Length > 0)
            {
                foreach (Weapon weapon in weapons)
                {
                    Console.WriteLine($"{startWeaponIndex}.{weapon.Name},");
                    startWeaponIndex++;
                }
                Console.WriteLine();

                Console.Write("Seçmək istədiyiniz silahın indexsini yazın: ");
                string weaponIndexInput = Console.ReadLine();
                int weaponIndex;

                if (int.TryParse(weaponIndexInput, out weaponIndex) && weaponIndex >= 0 && weaponIndex < weapons.Length)
                {
                    WeaponUse(weaponIndex);
                }
                else
                {
                    Console.WriteLine("Yanlış indeks daxil etdiniz.");
                }
            }
            else
            {
                Console.WriteLine("Heçbir silah mövcud deyil, əsas menudan silah əlavə edin.");
            }
        }

        static void WeaponUse(int weaponIndex)
        {
            Weapon weapon = weapons[weaponIndex];

            bool isTrueWeaponUse = true;

            while (isTrueWeaponUse)
            {
                Console.Clear();
                Console.WriteLine("""
                0 - İnformasiya almaq üçün
                1 - Shoot metodu üçün
                2 - Fire metodu üçün
                3 - GetRemainBulletCount metodu üçün
                4 - Reload metodu üçün
                5 - ChangeFireMode metodu üçün
                6 - Əsas menuya qayıtmaq üçün
                7 - Birdəfəlik çıxmaq üçün
            """);

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "0":
                        WeaponInfo(weaponIndex);
                        break;
                    case "1":
                        weapon.Shoot(); 
                        break;
                    case "2":
                        weapon.Fire(); 
                        break;
                    case "3":
                        int remainingBullets = weapon.GetRemainBulletCount(); 
                        Console.WriteLine($"Darağın dolması üçün lazımi güllə sayı: {remainingBullets}");
                        break;
                    case "4":
                        weapon.Reload(); 
                        break;
                    case "5":
                        weapon.ChangeFireMode(); 
                        break;
                    case "6":
                        isTrueWeaponUse = false; 
                        break;
                    case "7":
                        Environment.Exit(0); 
                        break;
                    default:
                        Console.WriteLine("Yanlış seçim etdiniz.");
                        break;
                }

                Console.WriteLine("Menyuya qayıtmaq üçün Enter düyməsini basın...");
                Console.ReadLine();
            }
        }

        static void WeaponInfo(int weaponIndex)
        {
            Weapon weapon = weapons[weaponIndex];
            Console.WriteLine(
                $"""
            Silahın adı : {weapon.Name}
            Silahın mərmi tutumu : {weapon.AmmoCapacity}
            Silahda olan mərmi : {weapon.CurrentAmmo}
            Silahın atış modu : {weapon.FireMode}
            """
            );
        }

        static void AddNewWeapon()
        {
            Console.Write("Silahın adını daxil edin: ");
            string weaponName = Console.ReadLine();
            Console.Write("Silahın daraq tutumunu daxil edin: ");
            string AmmoCapacityInput = Console.ReadLine();

            int AmmoCapacity = int.Parse(AmmoCapacityInput);
            AddWeapon(weaponName, AmmoCapacity);
        }

        static void AddWeapon(string name, int ammoCapacity)
        {
            Weapon newWeapon = new Weapon(name, ammoCapacity);

            Array.Resize(ref weapons, weapons.Length + 1);
            weapons[weapons.Length - 1] = newWeapon;

            Console.WriteLine($"{name} silahı əlavə olundu.");
        }
    }

}
