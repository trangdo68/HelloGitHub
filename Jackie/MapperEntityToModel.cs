using System;
using System.Collections.Generic;
using System.Linq;

using CMHGAdminData.Models;
using CMHGAdminDataObjects;
using AutoMapper;


namespace CMHGAdminDomain.Mapping
{
    public class SimpleMappings : Profile
    {
        public SimpleMappings()
        {
            CreateMap<TblResourcePending, ResourcePendingObj>();
            CreateMap<TblResourcePendingSearch, ResourcePendingSearchObj>();
            CreateMap<TblResourceReviewStatus, ResourceReviewStatusObj>();
            CreateMap<TblResourcePublishingStatus, ResourcePublishingStatusObj>();
            CreateMap<TblClassification, ResourceClassificationObj>();
            CreateMap<TblCoverageSpatial, ResourceCoverageSpatialObj>();
            CreateMap<TblLearningResourceType, ResourceLearningTypeObj>();
            CreateMap<TblFormat, ResourceFormatObj>();
            CreateMap<TblLinkType, ResourceLinkTypeObj>();
            CreateMap<TblRole, RoleObj>()
                    .ForMember(obj => obj.ModulesOfRole, obj => obj.MapFrom(tbl => tbl.TblRoleModules))
                    .ForMember(obj => obj.RightsOfRole, obj => obj.MapFrom(tbl => tbl.TblRoleRights));                 

            CreateMap<TblRoles, RolesObj>()
                    .ForMember(obj => obj.SiteDesc, obj => obj.MapFrom(tbl => tbl.Site.TitleShortE))
                    .ForMember(obj => obj.RoleDesc, obj => obj.MapFrom(tbl => tbl.Role.LabelE));

            CreateMap<TblSite, SiteObj>();
            CreateMap<TblRoleRights, RoleRightsObj>()
                    .ForMember(obj => obj.RightDesc, obj => obj.MapFrom(tbl => tbl.Right.DescriptionE));

            CreateMap<TblRoleModules, RoleModulesObj>()
                    .ForMember(obj => obj.ModuleDesc, obj => obj.MapFrom(tbl => tbl.Module.LabelE));

            CreateMap<TblRight, RightObj>();
            CreateMap<TblModule, ModuleObj>();
            CreateMap<TblUser, UserObj>();

            //foreach (var item in roleEF.TblRoleModules)
            //{
            //    role.ModulesOfRole.Add(item.Module.LabelE);
            //}

            //foreach (var item in roleEF.TblRoleRights)
            //{
            //    role.RightsOfRole.Add(item.Right.DescriptionE);
            //}
            //    Mapper.CreateMap<TrnsOutShipDto, TrnsShip>()
            //        .ForMember(m => m.ShipTrnsNo, o => o.MapFrom(s => s.TrnsNo));
            //    Mapper.CreateMap<ShipUserInfoDto, ShipUserInfo>();
            //    Mapper.CreateMap<LsaDto, Outstanding>();
            //    Mapper.CreateMap<TRNS_LD, TrnsLd>()
            //        .ForMember(m => m.ShipId, o => o.MapFrom(s => s.SHIP_ID))
            //        .ForMember(m => m.ShipUserCd, o => o.MapFrom(s => s.SHIP_USER_CD))
            //        .ForMember(m => m.CardSeqNo, o => o.MapFrom(s => s.CARD_SEQ_NO))
            //        .ForMember(m => m.IoShipInd, o => o.MapFrom(s => s.IO_SHIP_IND))
            //        .ForMember(m => m.NatoTrnsId, o => o.MapFrom(s => s.NATO_TRNS_ID))
            //        .ForMember(m => m.PckSeqNo, o => o.MapFrom(s => s.PCKG_SEQ_NO))
            //        .ForMember(m => m.PriIndCd, o => o.MapFrom(s => s.PRI_IND_CD))
            //        .ForMember(m => m.UserCd, o => o.MapFrom(s => s.USER_CD))
            //        .ForMember(m => m.MoeUserCd, o => o.MapFrom(s => s.MOE_USER_CD))
            //        .ForMember(m => m.TpckNatoDte, o => o.MapFrom(s => s.TPCK_NATO_DTE))
            //        .ForMember(m => m.TpckNatoDocSn, o => o.MapFrom(s => s.TPCK_NATO_DOC_SN))
            //        .ForMember(m => m.NatoKeyDta, o => o.MapFrom(s => s.NATO_KEY_DTA))
            //        .ForMember(m => m.ReqSegTypCd, o => o.MapFrom(s => s.REQ_SEG_TYP_CD))
            //        .ForMember(m => m.NatoLdDta, o => o.MapFrom(s => s.NATO_LOAD_DTA))
            //        .ForMember(m => m.RecProInd, o => o.MapFrom(s => s.REC_PROC_IND))
            //        .ForMember(m => m.PckTrnsId, o => o.MapFrom(s => s.PCKG_TRNS_ID))
            //        .ForMember(m => m.ResendFlg, o => o.MapFrom(s => s.RESEND_FLG));

            //    Mapper.CreateMap<TxnFilter, TxnFilterDto>()
            //        .ForMember(m => m.TpckDteOper, o => o.MapFrom(s =>
            //            s.TpckDte.HasValue ? s.CurrentPrjIdFilterOper.Id : ConditionalOperatorDto.None))
            //        .ForMember(m => m.OrgTpckDteOper, o => o.MapFrom(s =>
            //            s.OrgTpckDte.HasValue ? s.CurrentOrgPrjIdFilterOper.Id : ConditionalOperatorDto.None))
            //        .ForMember(m => m.StatusDteOper, o => o.MapFrom(s =>
            //            s.StatusDate.HasValue ? s.CurrentStatusDteFilterOper.Id : ConditionalOperatorDto.None))
            //        .ForMember(m => m.DocRcvdDteOper, o => o.MapFrom(s =>
            //            s.DocRcvdDate.HasValue ? s.CurrentDocRcvdDteFilterOper.Id : ConditionalOperatorDto.None))
            //        .ForMember(m => m.TxnStatusOper, o => o.MapFrom(s =>
            //            string.IsNullOrEmpty(s.TrnsStCd) ? ConditionalOperatorDto.None : s.CurrentTxnStatusFilterOper.Id));

            //    Mapper.CreateMap<NcagePrefixDto, NcagePrefix>();
            //    Mapper.CreateMap<NscMiOpiDto, NscMiOpi>();
            //    Mapper.CreateMap<NCAGE_DATA, NcagePrefix>()
            //        .ForMember(t => t.CageCd, o => o.MapFrom(s => s.CAGE_CD))
            //        .ForMember(t => t.Prefix, o => o.MapFrom(s => s.CAGE_DATA_PREFIX))
            //        .ForMember(t => t.Description, o => o.MapFrom(s => s.CAGE_DATA));

        }
    }



    

    public static class MapperEntityToModel
    {
        public static List<ResourceClassificationObj> MagicMapper(this ICollection<TblClassification> items, IMapper _mapper)
        {
            if (items == null) return null;

            List<ResourceClassificationObj> obj = new List<ResourceClassificationObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper(_mapper));
            }

            return obj;
        }

        public static ResourceClassificationObj MagicMapper(this TblClassification item, IMapper _mapper)
        {
            if (item == null) return null;

            var mapObj = _mapper.Map<TblClassification, ResourceClassificationObj>(item);

            return mapObj;

        }


        public static List<ResourceCoverageSpatialObj> MagicMapper(this ICollection<TblCoverageSpatial> items, IMapper _mapper)
        {
            if (items == null) return null;

            List<ResourceCoverageSpatialObj> obj = new List<ResourceCoverageSpatialObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper(_mapper));
            }

            return obj;
        }

        public static ResourceCoverageSpatialObj MagicMapper(this TblCoverageSpatial item, IMapper _mapper)
        {
            if (item == null) return null;

            var mapObj = _mapper.Map<TblCoverageSpatial, ResourceCoverageSpatialObj>(item);

            return mapObj;

        }


        public static List<ResourceLearningTypeObj> MagicMapper(this ICollection<TblLearningResourceType> items, IMapper _mapper)
        {
            if (items == null) return null;

            List<ResourceLearningTypeObj> obj = new List<ResourceLearningTypeObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper(_mapper));
            }

            return obj;
        }

        public static ResourceLearningTypeObj MagicMapper(this TblLearningResourceType item, IMapper _mapper)
        {
            if (item == null) return null;

            var mapObj = _mapper.Map<TblLearningResourceType, ResourceLearningTypeObj>(item);

            return mapObj;

        }

        public static List<ResourceFormatObj> MagicMapper(this ICollection<TblFormat> items, IMapper _mapper)
        {
            if (items == null) return null;

            List<ResourceFormatObj> obj = new List<ResourceFormatObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper(_mapper));
            }

            return obj;
        }

        public static ResourceFormatObj MagicMapper(this TblFormat item, IMapper _mapper)
        {
            if (item == null) return null;

            var mapObj = _mapper.Map<TblFormat, ResourceFormatObj>(item);

            return mapObj;

        }

        public static List<ResourceLinkTypeObj> MagicMapper(this ICollection<TblLinkType> items, IMapper _mapper)
        {
            if (items == null) return null;

            List<ResourceLinkTypeObj> obj = new List<ResourceLinkTypeObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper(_mapper));
            }

            return obj;
        }

        public static ResourceLinkTypeObj MagicMapper(this TblLinkType item, IMapper _mapper)
        {
            if (item == null) return null;

            var mapObj = _mapper.Map<TblLinkType, ResourceLinkTypeObj>(item);

            return mapObj;

        }


        public static List<ResourcePendingObj> MagicMapper(this ICollection<TblResourcePending> items, IMapper _mapper)
        {
            if (items == null) return null;

            List<ResourcePendingObj> obj = new List<ResourcePendingObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper(_mapper));
            }

            return obj;
        }

        public static ResourcePendingObj MagicMapper(this TblResourcePending item, IMapper _mapper)
        {
            if (item == null) return null;

            var mapObj = _mapper.Map<TblResourcePending, ResourcePendingObj>(item);
            
            mapObj.ResourcePendingSearchObj = _mapper.Map<TblResourcePendingSearch, ResourcePendingSearchObj>(item.TblResourcePendingSearch);

            //ResourcePendingObj obj = new ResourcePendingObj
            //{
            //    ResourceId = item.ResourceId,
            //    SiteId = item.SiteId,
            //    PublishStatusId = item.PublishstatusId,
            //    ReviewStatusId = item.ReviewstatusId,
            //    IsActive = item.Active,
            //    DateModified = item.DateModified,
            //    DcTitle = item.TblResourcePendingSearch.DcTitle,
            //    Creator = item.TblUser.Firstname + " " + item.TblUser.Lastname
            //};

          

            return mapObj;

        }

        public static List<ResourceReviewStatusObj> MagicMapper(this ICollection<TblResourceReviewStatus> items, IMapper _mapper)
        {
            if (items == null) return null;

            List<ResourceReviewStatusObj> obj = new List<ResourceReviewStatusObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper(_mapper));
            }

            return obj;
        }

        public static ResourceReviewStatusObj MagicMapper(this TblResourceReviewStatus item, IMapper _mapper)
        {
            if (item == null) return null;

            var mapObj = _mapper.Map<TblResourceReviewStatus, ResourceReviewStatusObj>(item);

            return mapObj;

        }

        public static List<ResourcePublishingStatusObj> MagicMapper(this ICollection<TblResourcePublishingStatus> items, IMapper _mapper)
        {
            if (items == null) return null;

            List<ResourcePublishingStatusObj> obj = new List<ResourcePublishingStatusObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper(_mapper));
            }

            return obj;
        }

        public static ResourcePublishingStatusObj MagicMapper(this TblResourcePublishingStatus item, IMapper _mapper)
        {
            if (item == null) return null;

            var mapObj = _mapper.Map<TblResourcePublishingStatus, ResourcePublishingStatusObj>(item);

            return mapObj;

        }
        public static List<OrganizationObj> MagicMapper(this ICollection<TblOrganization> items)
        {
            if (items == null) return null;

            List<OrganizationObj> obj = new List<OrganizationObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper());
            }

            return obj;
        }

        public static OrganizationObj MagicMapper(this TblOrganization item)
        {
            if (item == null) return null;

            OrganizationObj obj = new OrganizationObj
            {
                OrganizationId = item.OrganizationId,
                SiteId = item.SiteId,
                LabelE = item.LabelE,
                AcronymE = item.AcronymE,
                LabelF = item.LabelF,
                AcronymF = item.AcronymF,
                Active = item.Active
            };

            return obj;

        }

        public static List<SiteObj> MagicMapper(this ICollection<TblSite> items)
        {
            if (items == null) return null;

            List<SiteObj> obj = new List<SiteObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper());
            }

            return obj;
        }

        public static SiteObj MagicMapper(this TblSite item)
        {
            if (item == null) return null;

            SiteObj obj = new SiteObj
            {
                SiteId = item.SiteId,
                TitleShortE = item.TitleShortE
            };

            return obj;

        }


        public static List<RolesObj> MagicMapper(this ICollection<TblRoles> items)
        {
            if (items == null) return null;

            List<RolesObj> obj = new List<RolesObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper());
            }

            return obj;
        }

        public static RolesObj MagicMapper(this TblRoles item)
        {
            if (item == null) return null;

            RolesObj obj = new RolesObj
            {
                RolesId = item.RolesId,
                SiteId = item.SiteId,
                RoleDesc = item.Role.LabelE,
                SiteDesc = item.Site.TitleShortE
            };

            return obj;

        }

        public static List<RoleObj> MagicMapper(this ICollection<TblRole> items)
        {
            if (items == null) return null;

            List<RoleObj> obj = new List<RoleObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper());
            }

            return obj;
        }

        public static RoleObj MagicMapper(this TblRole item)
        {
            if (item == null) return null;

            RoleObj obj = new RoleObj
            {
                RoleId = item.RoleId,
                LabelE = item.LabelE,
                DescriptionE = item.DescriptionE

            };

            
            //TODO: This were collections.. Gonna leave this liek this for now. 
            //obj.AdAdditionalInfo = item.AdAdditionalInfo.FirstOrDefault().MagicMapper();
            //obj.AdMapInfo = item.AdMapInfo.FirstOrDefault().MagicMapper();
            //obj.AdRegionalPlacement = item.AdRegionalPlacement.FirstOrDefault().MagicMapper();
            //obj.Images = item.Image.MagicMapper();
            //obj.AdFlags = item.AdFlag.MagicMapper();
            //obj.AdPublishKeys = item.AdPublishKey.MagicMapper();

            return obj;

        }

        public static List<UserObj> MagicMapper(this ICollection<TblUser> items)
        {
            if (items == null) return null;

            List<UserObj> obj = new List<UserObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper());
            }

            return obj;
        }

        public static UserObj MagicMapper(this TblUser item)
        {
            if (item == null) return null;

            //List<RoleObj> listRoles;
            //foreach (var x in item.TblRoles)
            //{

            //   listRoles.Add
            //}

            UserObj obj = new UserObj
            {
                UserId = item.UserId,
                Firstname = item.Firstname,
                Lastname = item.Lastname,
                Phone = item.Phone,
                Fax = item.Fax,
                Username = item.Username,
                EmailSmtp = item.EmailSmtp,
                Active = item.Active
            };

            //obj.TblRoles = item.TblRoles.
  
            return obj;

        }


        public static List<ModuleObj> MagicMapper(this ICollection<TblModule> items)
        {
            if (items == null) return null;

            List<ModuleObj> obj = new List<ModuleObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper());
            }

            return obj;
        }

        public static ModuleObj MagicMapper(this TblModule item)
        {
            if (item == null) return null;

            ModuleObj obj = new ModuleObj
            {
               LabelE = item.LabelE,
               ParentId = item.ParentId
            };

            return obj;

        }

        public static List<ConfigurationObj> MagicMapper(this ICollection<TblConfiguration> items)
        {
            if (items == null) return null;

            List<ConfigurationObj> obj = new List<ConfigurationObj>();

            foreach (var x in items)
            {
                obj.Add(x.MagicMapper());
            }

            return obj;
        }

        public static ConfigurationObj MagicMapper(this TblConfiguration item)
        {
            if (item == null) return null;

            ConfigurationObj obj = new ConfigurationObj
            {
               ApplicationName = item.ApplicationName,
               HostAddress = item.HostAddress,
               MailServer = item.MailServer,
               BookImageFileExtension = item.BookImageFileExtension,
               BookMediaImageFileExtension = item.BookMediaImageFileExtension,
               BookMediaMediaFileExtension = item.BookMediaMediaFileExtension
            };

            return obj;

        }




    }




}
