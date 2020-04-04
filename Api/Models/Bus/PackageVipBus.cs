using Api.Models.Dao;
using Api.Models.EF;
using ModelViews.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Models.Bus
{
    public class PackageVipBus
    {
        public bool CreatePackageVip(PackageVipDTO packageVip)
        {
            try
            {
                var data = new PackageVipDao().CreatePackageVip(new PackageVip()
                {
                    PVipMonths = packageVip.PVipMonths,
                    PVipName = packageVip.PVipName,
                    PVipPrice = packageVip.PVipPrice,
                });

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdatePackageVip(PackageVipDTO packageVip)
        {
            try
            {
                new PackageVipDao().Update(new PackageVip()
                {
                    ID = packageVip.ID,
                    PVipMonths = packageVip.PVipMonths,
                    PVipName = packageVip.PVipName,
                    PVipPrice = packageVip.PVipPrice,
                });

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool UpdatePackageVip(int id)
        {
            try
            {
                new PackageVipDao().Delete(id);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public IEnumerable<PackageVipDTO> GetAllPackageVip()
        {
            try
            {
                return new PackageVipDao().GetAll()
                    .Select(packageVip => new PackageVipDTO()
                    {
                        ID = packageVip.ID,
                        PVipName = packageVip.PVipName,
                        PVipPrice = packageVip.PVipPrice,
                        PVipMonths = packageVip.PVipMonths,
                    })
                    .ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public PackageVipDTO GetPackageVipById(int id)
        {
            try
            {
                var data = new PackageVipDao().GetById(id);
                return new PackageVipDTO()
                {
                    ID = data.ID,
                    PVipName = data.PVipName,
                    PVipPrice = data.PVipPrice,
                    PVipMonths = data.PVipMonths
                };
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public bool DeletePackageVip(int id)
        {
            try
            {
                new PackageVipDao().Delete(id);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}