NETWORK_LAYERS = 'layers'
NETWORK_PARAMS = 'params'
NETWORK_TYPE = 'type'
DATA_TYPE = 'data_type'

get_network_layers = lambda data: data[NETWORK_LAYERS]
get_network_params = lambda data: data[NETWORK_PARAMS]
get_type = lambda data: data[NETWORK_TYPE]
get_data_type = lambda data: data[DATA_TYPE]
get_input_shape = lambda data: data[NETWORK_LAYERS][0]['params']['input_shape']
get_output_shape = lambda data: data[NETWORK_LAYERS][-1]['params']['units']
