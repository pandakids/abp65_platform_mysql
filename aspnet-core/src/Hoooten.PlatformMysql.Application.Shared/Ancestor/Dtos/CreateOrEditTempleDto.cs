
using System;
using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace Hoooten.PlatformMysql.Ancestor.Dtos
{
    public class CreateOrEditTempleDto : FullAuditedEntityDto<int?>
    {
        /// <summary>
        /// ����
        /// </summary>
        [Required]
        [StringLength(TempleConsts.MaxNameLength, MinimumLength = TempleConsts.MinNameLength)]
        public string Name { get; set; }


        /// <summary>
        /// ���
        /// </summary>
        [StringLength(TempleConsts.MaxCodeLength, MinimumLength = TempleConsts.MinCodeLength)]
        public string Code { get; set; }

        /// <summary>
        /// �գ��������...��
        /// </summary>
        [Required]
        [StringLength(TempleConsts.MaxFamilyNameLength, MinimumLength = TempleConsts.MinFamilyNameLength)]
        public string FamilyName { get; set; }

        /// <summary>
        /// ��ַ(���ݾ�γ�Ȼ�õ�ǰλ�õ�ַ)
        /// </summary>
        [StringLength(TempleConsts.MaxAddressLength, MinimumLength = TempleConsts.MinAddressLength)]
        public string Address { get; set; }

        /// <summary>
        /// ͼƬ
        /// </summary>
        [StringLength(TempleConsts.MaxPhotoLength, MinimumLength = TempleConsts.MinPhotoLength)]
        public string Photo { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public double Lon { get; set; }

        /// <summary>
        /// γ��
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// �ϴ���ͼƬ�Ļش�guid
        /// </summary>
        public Guid? BinaryObjectId { get; set; }

        /// <summary>
        /// ���ù���ԱId
        /// </summary>
        public long? UserId { get; set; }

        /// <summary>
        /// ����Id�����ݾ�γ�Ȼ�õ�ǰλ�õ�ַ�󣬿����õ�������Ϣ�Լ�CityId��
        /// </summary>
        public int? CityId { get; set; }


    }
}