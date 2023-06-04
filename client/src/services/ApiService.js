import axios from 'axios'
class ApiService {

    getAllApi() {
        return axios.get('https://api.publicapis.org/entries').then((response) => {
            return response.data;
        })
    }

    insert(data) {
        return axios.post('https://api.publicapis.org/entries', data).then((response) => {
            return response.data;
        })
    }
}

export default new ApiService;


