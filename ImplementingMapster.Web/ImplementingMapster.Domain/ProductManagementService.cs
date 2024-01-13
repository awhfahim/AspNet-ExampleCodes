using MapsterMapper;

namespace ImplementingMapster.Domain;

public class ProductManagementService
{
    private IMapper _mapper;
    public ProductManagementService()
    {
        
    }

    public ProductManagementService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<ProductDto> GetProducts()
    {
        var product = new Product { Id = 1, Name = "Camera", Price = "323242", Weight = 232 };
        var dto = _mapper.Map<ProductDto>(product);
        return dto;
    }
}