
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class CreateOrEditTempleDto : FullAuditedEntityDto<int?>
    {
        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [StringLength(TempleConsts.MaxNameLength, MinimumLength = TempleConsts.MinNameLength)]
        public string Name { get; set; }


        /// <summary>
        /// 编号
        /// </summary>
        [StringLength(TempleConsts.MaxCodeLength, MinimumLength = TempleConsts.MinCodeLength)]
        public string Code { get; set; }

        /// <summary>
        /// 姓（李，单，张...）
        /// </summary>
        [Required]
        [StringLength(TempleConsts.MaxFamilyNameLength, MinimumLength = TempleConsts.MinFamilyNameLength)]
        public string FamilyName { get; set; }

        /// <summary>
        /// 地址(根据经纬度获得当前位置地址)
        /// </summary>
        [StringLength(TempleConsts.MaxAddressLength, MinimumLength = TempleConsts.MinAddressLength)]
        public string Address { get; set; }

        /// <summary>
        /// 图片
        /// </summary>
        [StringLength(TempleConsts.MaxPhotoLength, MinimumLength = TempleConsts.MinPhotoLength)]
        public string Photo { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        public double Lon { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// 上传的图片的回传guid
        /// </summary>
        public Guid? BinaryObjectId { get; set; }

        /// <summary>
        /// 宗堂管理员Id
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// 城市Id（根据经纬度获得当前位置地址后，可以拿到城市信息以及CityId）
        /// </summary>
        public int? CityId { get; set; }


    }
}