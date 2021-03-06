import axios from 'axios';


const axiosInstance = axios.create({
    baseURL: '/api/'
});

axiosInstance.interceptors.response.use(response => response.data);

export default axiosInstance;
