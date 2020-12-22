using AutoMapper;
using HQPosData.Models;
using CentralService.Injection;
using CentralService.Models;
using HQService.Services;
using Unity;
using Unity.Extension;
using Unity.Lifetime;
using CentralService.Services;
using CentralService.Enums;
using System;
using System.Collections.Generic;
using CentralService.Models.SystemData;
using CentralService.Models.MasterData.Campaign;
using CampaignModel = CentralService.Models.MasterData.Campaign.CampaignModel;

namespace HQService
{
    public class HQServiceUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<Mapper>(new TransientLifetimeManager());
            Container.RegisterType<ITransferDataService, TransferDataService>(new TransientLifetimeManager());
            Container.RegisterType<IUserAccountService, UserAccountService>(new TransientLifetimeManager());
            Container.RegisterType<IDocService, DocService>(new TransientLifetimeManager());
            Container.RegisterType<IMovementProductService, MovementProductService>(new TransientLifetimeManager());
            Container.RegisterType<IDashboardService, DashboardService>(new TransientLifetimeManager());
            Container.RegisterType<IMessageService, MessageService>(new TransientLifetimeManager());
            Container.RegisterType<IPaymentService, PaymentService>(new TransientLifetimeManager());
            Container.RegisterType<IDropDownService, DropDownService>(new TransientLifetimeManager());
            Container.RegisterType<IProductService, ProductService>(new TransientLifetimeManager());
            Container.RegisterType<ICustomerService, CustomerService>(new TransientLifetimeManager());
            Container.RegisterType<IPromotionService, PromotionService>(new TransientLifetimeManager());
            Container.RegisterType<IMasterDataModelService, MasterDataService>(new TransientLifetimeManager());
            Container.RegisterType<IExcelMgmtService, ExcelMgmtService>(new TransientLifetimeManager());
            Container.RegisterType<IBranchService, BranchService>(new TransientLifetimeManager());
            Container.RegisterType<ICampaignService, CampaignService>(new TransientLifetimeManager());
        }

        public class Mapper
        {
            private IMapper _iMapper;

            public Mapper()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<SB_Branch, BranchModel>().ReverseMap();
                    cfg.CreateMap<SB_System, SystemModel>().ReverseMap();
                    cfg.CreateMap<SB_Campaign, CampaignModel>().ReverseMap();

                    cfg.CreateMap<MessageModel, MessageData>();
                    cfg.CreateMap<MessageData, MessageModel>()
                    .ForMember(x => x.DateRange, m => m.Ignore())
                    .ForMember(x => x.StatusName, m => m.MapFrom(a => Enum.GetName(typeof(MessageStatus), a.Status)));

                    cfg.CreateMap<ExtraDiscountIconModel, SB_ExtraDiscount>();
                    cfg.CreateMap<SB_ExtraDiscount, ExtraDiscountIconModel>()
                    .ForMember(x => x.ProgroupCode, m => m.MapFrom(a => a.ProgroupCode.Replace(" ", string.Empty)))
                    .ForMember(x => x.CustypeCode, m => m.MapFrom(a => a.CustypeCode.Replace(" ", string.Empty)));

                    //cfg.CreateMap<ExtraPromotionModel, SB_PromotionHeader>();

                    cfg.CreateMap<SB_PromotionHeader, ExtraPromotionModel>().ReverseMap()
                        .ForMember(dest => dest.SbPromotionDetail,
                        opts => opts.MapFrom(src => src.SbPromotionDetail));
                    cfg.CreateMap<SB_PromotionDetail, SbPromotionDetail>().ReverseMap();

                    //cfg.CreateMap<ExtraPromotionModel, SB_PromotionHeader>()
                    //    .ForMember(dest => dest.SbPromotionDetail,
                    //        opts => opts.MapFrom(src => src.SbPromotionDetail));

                    //cfg.CreateMap<SB_PromotionHeader, ExtraPromotionModel>()
                    //    .ForMember(dest => dest.SbPromotionDetail,
                    //        opts => opts.MapFrom(src => src.SbPromotionDetail));
                });

                _iMapper = config.CreateMapper();
            }

            public O Map<I, O>(I model)
            {
                return _iMapper.Map<I, O>(model);
            }

            public O Map<O>(dynamic model)
            {
                return _iMapper.Map<dynamic, O>(model);
            }

            public O Map<I, I2, O>(I model, I2 model2)
            {
                O m = _iMapper.Map<I, O>(model);
                return _iMapper.Map<I2, O>(model2, m);
            }
        }
    }
}
