import axios from 'axios';

const API_URL = 'http://localhost:5031/api/v1';


const getUserAgent = () => {
  return navigator.userAgent || 'unknown';
};

export const getAllNews = async () => {
  try {
    const response = await axios.get(`${API_URL}/News`, {
      headers: {
        'User-Agent': getUserAgent(),
      },
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching news:', error);
    throw error;
  }
};

export const getNewsById = async (id) => {
  try {
    const response = await axios.get(`${API_URL}/News/${id}`);
    return response.data;
  } catch (error) {
    console.error(`Error fetching news with id ${id}:`, error);
    throw error;
  }
};

export const addNews = async (newsData) => {
  try {
    const response = await axios.post(`${API_URL}/News`, newsData);
    return response.data;
  } catch (error) {
    console.error('Error adding news:', error);
    throw error;
  }
};

export const updateNews = async (id, newsData) => {
  try {
    const response = await axios.put(`${API_URL}/News/${id}`, newsData);
    return response.data;
  } catch (error) {
    console.error(`Error updating news with id ${id}:`, error);
    throw error;
  }
};

export const deleteNews = async (id) => {
  try {
    await axios.delete(`${API_URL}/News/${id}`);
  } catch (error) {
    console.error(`Error deleting news with id ${id}:`, error);
    throw error;
  }
};

export const getNewsByCategory = async (category) => {
  try {
    const response = await axios.get(`${API_URL}/News/category/${category}`, {
      headers: {
        'User-Agent': getUserAgent(),
      },
    });
    return response.data;
  } catch (error) {
    console.error(`Error fetching news for category ${category}:`, error);
    throw error;
  }
};

export const getLatestNews = async (quantity) => {
  try {
    const response = await axios.get(`${API_URL}/News/latest/${quantity}`);
    return response.data;
  } catch (error) {
    console.error('Error fetching latest news:', error);
    throw error;
  }
};

export const searchNews = async (search) => {
  try {
    const response = await axios.get(`${API_URL}/News/search/${search}`, {
      headers: {
        'User-Agent': getUserAgent(),
      },
    });
    return response.data;
  } catch (error) {
    console.error(`Error searching news with query ${search}:`, error);
    throw error;
  }
};

export const getPaginatedNews = async (pageNumber, pageSize) => {
  try {
    const response = await axios.get(`${API_URL}/News/paginated`, {
      params: {
        pageNumber,
        pageSize,
      },
    });
    return response.data;
  } catch (error) {
    console.error('Error fetching paginated news:', error);
    throw error;
  }
};
