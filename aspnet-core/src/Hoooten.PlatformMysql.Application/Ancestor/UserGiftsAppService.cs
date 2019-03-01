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
	[AbpAuthorize(AppPermissions.Pages_UserGifts)]
    public class UserGiftsAppService : PlatformMysqlAppServiceBase, IUserGiftsAppService
    {
		 private readonly IRepository<UserGift> _userGiftRepository;
		 private readonly IRepository<User,long> _userRepository;
		 

		  public UserGiftsAppService(IRepository<UserGift> userGiftRepository , IRepository<User, long> userRepository) 
		  {
			_userGiftRepository = userGiftRepository;
			_userRepository = userRepository;
		
		  }

		 public async Task<PagedResultDto<GetUserGiftForView>> GetAll(GetAllUserGiftsInput input)
         {

			var filteredUserGifts = _userGiftRepository.GetAll()
						.WhereIf(!string.IsNullOrWhiteSpace(input.Filter), e => false );


			var query = (from o in filteredUserGifts
                         join o1 in _userRepository.GetAll() on o.UserId equals o1.Id into j1
                         from s1 in j1.DefaultIfEmpty()
                         
                         select new GetUserGiftForView() { UserGift = ObjectMapper.Map<UserGiftDto>(o)
						 , UserName = s1 == null ? "" : s1.Name.ToString()
					
						 })
						 
						.WhereIf(!string.IsNullOrWhiteSpace(input.UserNameFilter), e => e.UserName.ToLower() == input.UserNameFilter.ToLower().Trim());

            var totalCount = await query.CountAsync();

            var userGifts = await query
                .OrderBy(input.Sorting ?? "userGift.id asc")
                .PageBy(input)
                .ToListAsync();

            return new PagedResultDto<GetUserGiftForView>(
                totalCount,
                userGifts
            );
         }
		 
		 [AbpAuthorize(AppPermissions.Pages_UserGifts_Edit)]
		 public async Task<GetUserGiftForEditOutput> GetUserGiftForEdit(EntityDto input)
         {
            var userGift = await _userGiftRepository.FirstOrDefaultAsync(input.Id);
            var output = new GetUserGiftForEditOutput {UserGift = ObjectMapper.Map<CreateOrEditUserGiftDto>(userGift)};

			if (output.UserGift.UserId != null)
            {
                var user = await _userRepository.FirstOrDefaultAsync((long)output.UserGift.UserId);
                output.UserName = user.Name.ToString();
            }
			
			
            return output;
         }

		 public async Task CreateOrEdit(CreateOrEditUserGiftDto input)
         {
            if(input.Id == null){
				await Create(input);
			}
			else{
				await Update(input);
			}
         }

		 [AbpAuthorize(AppPermissions.Pages_UserGifts_Create)]
		 private async Task Create(CreateOrEditUserGiftDto input)
         {
            var userGift = ObjectMapper.Map<UserGift>(input);

			

            await _userGiftRepository.InsertAsync(userGift);
         }

		 [AbpAuthorize(AppPermissions.Pages_UserGifts_Edit)]
		 private async Task Update(CreateOrEditUserGiftDto input)
         {
            var userGift = await _userGiftRepository.FirstOrDefaultAsync((int)input.Id);
             ObjectMapper.Map(input, userGift);
         }

		 [AbpAuthorize(AppPermissions.Pages_UserGifts_Delete)]
         public async Task Delete(EntityDto input)
         {
            await _userGiftRepository.DeleteAsync(input.Id);
         }

		 		 [AbpAuthorize(AppPermissions.Pages_UserGifts)]
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
    }
}