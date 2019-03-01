using Hoooten.PlatformMysql.Ancestor;
using Hoooten.PlatformMysql.Authorization.Users;

using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using Abp.Linq.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Hoooten.PlatformMysql.Ancestor.Exporting;
using Hoooten.PlatformMysql.Ancestor.Dtos;
using Hoooten.PlatformMysql.Dto;
using Abp.Application.Services.Dto;
using Hoooten.PlatformMysql.Authorization;
using Abp.Authorization;
using Microsoft.EntityFrameworkCore;

namespace Hoooten.PlatformMysql.Ancestor
{
	[AbpAuthorize(AppPermissions.Pages_ForeFatherGifts)]
    public class ForeFatherGiftsAppService : PlatformMysqlAppServiceBase, IForeFatherGiftsAppService
    {
		 private readonly IRepository<ForeFatherGift> _foreFatherGiftRepository;
		 private readonly IRepository<ForeFather,int> _foreFatherRepository;
		 private readonly IRepository<User,long> _userRepository;
		 

		  public ForeFatherGiftsAppService(IRepository<ForeFatherGift> foreFatherGiftRepository , IRepository<ForeFather, int> foreFatherRepository, IRepository<User, long> userRepository) 
		  {
			_foreFatherGiftRepository = foreFatherGiftRepository;
			_foreFatherRepository = foreFatherRepository;
		_userRepository = userRepository;
		
		  }

		 public async Task<PagedResultDto<GetForeFatherGiftForView>> GetAll(GetAllForeFatherGiftsInput input)
         {

			var filteredForeFatherGifts = _foreFatherGiftRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false );


			var query = (from o in filteredForeFatherGifts
                         join o1 in _foreFatherRepository.GetAll() on o.ForeFatherId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         join o2 in _userRepository.GetAll() on o.UserId equals o2.Id into j2
                         from s2 in j2.DefaultIfEmpty()
                         
                         select new GetForeFatherGiftForView() { ForeFatherGift = ObjectMapper.Map<ForeFatherGiftDto>(o)
						 , ForeFatherName = s1 == null ? "" : s1.Name.ToString()
					, UserName = s2 == null ? "" : s2.Name.ToString()
					
						 })
						 
						.WhereIf(!string.IsNullOrWhiteSpace(input.ForeFatherNameFilter), e => e.ForeFatherName.ToLower() == input.ForeFatherNameFilter.ToLower().Trim())
						.WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserName.ToLower() == input.UserNameFilter.ToLower().Trim());

            var totalCount = await query.CountAsync();

            var foreFatherGifts = await query
                .OrderBy(input.Sorting ?? "foreFatherGift.id asc")
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetForeFatherGiftForView>(
                totalCount,
                foreFatherGifts
            );
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_ForeFatherGifts_Edit)]
		 public async Task<GetForeFatherGiftForEditOutput> GetForeFatherGiftForEdit(EntityDto input)
         {
            var foreFatherGift = await _foreFatherGiftRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetForeFatherGiftForEditOutput {ForeFatherGift = ObjectMapper.Map<CreateOrEditForeFatherGiftDto>(foreFatherGift)};

			if (output.ForeFatherGift.ForeFatherId != null)
            {
                var foreFather = await _foreFatherRepository.FirstOrDefaultAsync((int)output.ForeFatherGift.ForeFatherId);
                output.ForeFatherName = foreFather.Name.ToString();
            }
			if (output.ForeFatherGift.UserId != null)
            {
                var user = await _userRepository.FirstOrDefaultAsync((long)output.ForeFatherGift.UserId);
                output.UserName = user.Name.ToString();
            }
			
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditForeFatherGiftDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_ForeFatherGifts_Create)]
		 private async Task Create(CreateOrEditForeFatherGiftDto input)
         {
            var foreFatherGift = ObjectMapper.Map<ForeFatherGift>(input);

			

            await _foreFatherGiftRepository.InsertAsync(foreFatherGift);
         }

		 [AbpAuthorize(AppPermissions.Pages_ForeFatherGifts_Edit)]
		 private async Task Update(CreateOrEditForeFatherGiftDto input)
         {
            var foreFatherGift = await _foreFatherGiftRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, foreFatherGift);
         }

		 [AbpAuthorize(AppPermissions.Pages_ForeFatherGifts_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _foreFatherGiftRepository.DeleteAsync(input.Id);
         }

		 		 [AbpAuthorize(AppPermissions.Pages_ForeFatherGifts)]
         public async Task<PagedResultDto<ForeFatherLookupTableDto>> GetAllForeFatherForLookupTable(GetAllForLookupTableInput input)
         {
             var query = _foreFatherRepository.GetAll().WhereIf(
                    !string.IsNullOrWhiteSpace(input.Filter),
                   e=> e.Name.ToString().Contains(input.Filter)
                );

            var totalCount = await query.CountAsync();

            var foreFatherList = await query
                .PageBy(input)
                .ToListAsync();

			var lookupTableDtoList = new List<ForeFatherLookupTableDto>();
			foreach(var foreFather in foreFatherList){
				lookupTableDtoList.Add(new ForeFatherLookupTableDto
				{
					Id = foreFather.Id,
					DisplayName = foreFather.Name.ToString()
				});
			}

            return new PagedResultDto<ForeFatherLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
         }		 [AbpAuthorize(AppPermissions.Pages_ForeFatherGifts)]
         public async Task<PagedResultDto<UserLookupTableDto>> GetAllUserForLookupTable(GetAllForLookupTableInput input)
         {
             var query = _userRepository.GetAll().WhereIf(
                    !string.IsNullOrWhiteSpace(input.Filter),
                   e=> e.Name.ToString().Contains(input.Filter)
                );

            var totalCount = await query.CountAsync();

            var userList = await query
                .PageBy(input)
                .ToListAsync();

			var lookupTableDtoList = new List<UserLookupTableDto>();
			foreach(var user in userList){
				lookupTableDtoList.Add(new UserLookupTableDto
				{
					Id = user.Id,
					DisplayName = user.Name.ToString()
				});
			}

            return new PagedResultDto<UserLookupTableDto>(
                totalCount,
                lookupTableDtoList
            );
         }

        public Task SendGift(SendGiftInput input)
        {
            throw new NotImplementedException();
        }
    }
}