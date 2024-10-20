using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeaponProject
{
    internal class Weapon
    {
        public string Name { get; private set; }
        public int AmmoCapacity { get; private set; }
        public int CurrentAmmo { get; private set; }
        public string FireMode { get; private set; } = "Single"; 

      
        public Weapon(string name, int ammoCapacity)
        {
            Name = name;
            AmmoCapacity = ammoCapacity;
            CurrentAmmo = ammoCapacity;
        }

        // 1. Shoot() - Hər dəfə 1 güllə atır
        public void Shoot()
        {
            if (FireMode == "Single")
            {
                if (CurrentAmmo > 0)
                {
                    CurrentAmmo--;
                    Console.WriteLine($"{Name}: Bang! Qalan güllə: {CurrentAmmo}");
                }
                else
                {
                    Console.WriteLine($"{Name}: Daraq boşdur! Yenidən doldurun.");
                }
            }
            else Console.WriteLine($"Silahınızın atış modu {FireMode} rejimindədir. təkli atmaq istəyirsinizsa əvvəl modu dəyişdirməniz lazımdır. və ya Fire ilə auto atəş aça bilərsiz");

        }
        
        public void ShootForAuto()
        {
           
            if (CurrentAmmo > 0)
            {
                CurrentAmmo--;
            }
            else
            {
                Console.WriteLine($"{Name}: Daraq boşdur! Yenidən doldurun.");
            }
        }


        // 2. Fire() - Bütün güllələri atır və neçə saniyəyə bitdiyini qeyd edir
        public void Fire()
        {
            if (FireMode == "Auto")
            {
                if (CurrentAmmo > 0)
                {
                    var startTime = DateTime.Now;

                    while (CurrentAmmo > 0)
                    {
                        ShootForAuto(); 
                    }

                    var duration = DateTime.Now - startTime;
                    Console.WriteLine($"{Name}: Bütün güllələr atəşləndi. Vaxt: {duration.TotalSeconds} saniyə.");
                }
                else
                {
                    Console.WriteLine($"{Name}: Daraq artıq boşdur.");
                }
            }

            else Console.WriteLine($"Silahınızın atış modu {FireMode} rejimindədir. Auto atmaq istəyirsinizsa əvvəl modu dəyişdirməniz lazımdır. və ya Shoot metodu ilə tekli atəş aça bilərsiz");

        }

        // 3. GetRemainBulletCount() - Daraq tam dolması üçün lazım olan güllə sayını qaytarır

        public int GetRemainBulletCount()
        {
            int neededBullets = AmmoCapacity - CurrentAmmo;
            Console.WriteLine($"{Name}: Daraq tam dolması üçün {neededBullets} güllə lazımdır.");
            return neededBullets;
        }

        // 4. Reload() - Darağı yenidən doldurur
        public void Reload()
        {
            Console.WriteLine($"{Name}: Daraq doldurulur...");
            CurrentAmmo = AmmoCapacity;
            Console.WriteLine($"{Name}: Daraq tam doludur.");
        }

        // 5. ChangeFireMode() - Atış rejimini dəyişir
        public void ChangeFireMode()
        {
            FireMode = FireMode == "Single" ? "Auto" : "Single";
            Console.WriteLine($"{Name}: Atış rejimi '{FireMode}' olaraq dəyişdirildi.");
        }

    }
}
