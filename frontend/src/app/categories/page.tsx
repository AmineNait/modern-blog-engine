import React from 'react';
import CategoryList from '../../components/CategoryList';
import Container from '@mui/material/Container';
import Typography from '@mui/material/Typography';

const categories = [
  { id: 1, name: 'Technology' },
  { id: 2, name: 'Health' },
  { id: 3, name: 'Travel' },
];

const CategoriesPage: React.FC = () => {
  return (
    <Container>
      <Typography variant='h4' gutterBottom>
        Categories
      </Typography>
      <CategoryList categories={categories} />
    </Container>
  );
};

export default CategoriesPage;
