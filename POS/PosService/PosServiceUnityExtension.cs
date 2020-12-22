using AutoMapper;
using CentralService.Enums;
using CentralService.Injection;
using CentralService.Models;
using CentralService.Models.MasterData;
using CentralService.Models.MasterData.Campaign;
using CentralService.Models.Sale;
using CentralService.Models.SystemData;
using CentralService.Services;
using PosData.Models;
using PosService.Injection;
using PosService.Services;
using System;
using Unity;
using Unity.Extension;
using Unity.Lifetime;

namespace PosService
{
    public class PosServiceUnityExtension : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<Mapper>(new TransientLifetimeManager());
            Container.RegisterType<ITransferDataService, TransferDataService>(new TransientLifetimeManager());
            Container.RegisterType<IUserAccountService, UserAccountService>(new TransientLifetimeManager());
            Container.RegisterType<IDocService, DocService>(new TransientLifetimeManager());
            Container.RegisterType<IMovementProductService, MovementProductService>(new TransientLifetimeManager());
            Container.RegisterType<IDealerService, DealerService>(new TransientLifetimeManager());
            Container.RegisterType<IDashboardService, DashboardService>(new TransientLifetimeManager());
            Container.RegisterType<IJobService, JobService>(new TransientLifetimeManager());
            Container.RegisterType<IPaymentService, PaymentService>(new TransientLifetimeManager());
            Container.RegisterType<IDropDownService, DropDownService>(new TransientLifetimeManager());
            Container.RegisterType<IEDCService, EDCService>(new TransientLifetimeManager());
            Container.RegisterType<IMessageService, MessageService>(new TransientLifetimeManager());
            Container.RegisterType<ICustomerService, CustomerService>(new TransientLifetimeManager());
            Container.RegisterType<IPromotionService, PromotionService>(new TransientLifetimeManager());
            Container.RegisterType<IMasterDataModelService, MasterDataService>(new TransientLifetimeManager());
            Container.RegisterType<ICashDrawerService, CashDrawerService>(new TransientLifetimeManager());
            Container.RegisterType<IBranchService, BranchService>(new TransientLifetimeManager());
            Container.RegisterType<IProductService, ProductService>(new TransientLifetimeManager());
            Container.RegisterType<ICampaignService, CampaignService>(new TransientLifetimeManager());
            Container.RegisterType<IVendorService, VendorService>(new TransientLifetimeManager());
        }

        public class Mapper
        {
            private IMapper _iMapper;

            public Mapper()
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ST_Jobheader, JobModel>().ReverseMap();
                    cfg.CreateMap<ST_Jobtemp, JobTempModel>().ReverseMap();

                    cfg.CreateMap<SB_Product, ProductModel>().ReverseMap();
                    cfg.CreateMap<SB_Product_Set_Head, ProductSetModel>().ReverseMap();
                    cfg.CreateMap<SB_Product_Set_Detail, ProductSetDetailModel>().ReverseMap();

                    cfg.CreateMap<SB_Prolocation, locationModel>().ReverseMap();
                    cfg.CreateMap<SB_location, locationModel>().ReverseMap();

                    cfg.CreateMap<SB_Prolocation_dot, locationDotModel>().ReverseMap();
                    cfg.CreateMap<SB_Location_DOT, locationDotModel>().ReverseMap();

                    cfg.CreateMap<SB_CusCar, CusCarRegModel>().ReverseMap();
                    cfg.CreateMap<SB_Customer, CusCarRegModel>().ReverseMap();

                    cfg.CreateMap<SB_Branch, BranchModel>().ReverseMap();
                    cfg.CreateMap<SB_System, SystemModel>().ReverseMap();
                    cfg.CreateMap<SB_Campaign, CampaignModel>().ReverseMap();
                    cfg.CreateMap<SB_Vendor, VendorModel>().ReverseMap();
                    cfg.CreateMap<ExtraDiscountIconModel, SB_ExtraDiscount>();
                    cfg.CreateMap<SB_ExtraDiscount, ExtraDiscountIconModel>();
                    cfg.CreateMap<MessageModel, MessageData>();
                    cfg.CreateMap<MessageData, MessageModel>()
                    .ForMember(x => x.DateRange, m => m.Ignore())
                    .ForMember(x => x.StatusName, m => m.MapFrom(a => Enum.GetName(typeof(MessageStatus), a.Status)));

                    cfg.CreateMap<ExtraPromotionModel, SB_PromotionHeader>();
                    cfg.CreateMap<SB_PromotionHeader, ExtraPromotionModel>();

                    cfg.CreateMap<SB_PromotionDetail, SbPromotionDetail>().ReverseMap();

                    cfg.CreateMap<ExtraPromotionModel, SB_PromotionHeader>()
                        .ForMember(dest => dest.SB_PromotionDetail,
                            opts => opts.MapFrom(src => src.SbPromotionDetail));

                    cfg.CreateMap<SB_PromotionHeader, ExtraPromotionModel>()
                        .ForMember(dest => dest.SbPromotionDetail,
                            opts => opts.MapFrom(src => src.SB_PromotionDetail));
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
