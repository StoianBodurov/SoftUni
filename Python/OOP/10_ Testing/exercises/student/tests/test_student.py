from unittest import TestCase, main

from project.student import Student


class StudentTest(TestCase):
    def test_init_if_not_courses(self):
        student = Student('name')
        self.assertEqual('name', student.name)
        self.assertEqual({}, student.courses)

    def test_init_whit_courses(self):
        courses = {'a': ['a'], 'b': ['b']}
        student = Student('name', courses)
        self.assertEqual('name', student.name)
        self.assertEqual(courses, student.courses)

    def test_enroll_when_course_in_courses_expect_append_notes(self):
        courses = {'a': ['a']}
        notes = ['b', 'c', 'd']
        student = Student('Student name', courses)
        [courses['a'].append(x) for x in notes]
        self.assertEqual('Course already added. Notes have been updated.', student.enroll('a', notes, ''))
        self.assertEqual(courses, student.courses)

    def test_enroll_when_course_not_in_courses_and_add_courses_notes_Y_expect_append_courses_and_notes(self):
        student = Student('Name')
        notes = ['b', 'c', 'd']
        self.assertEqual('Course and course notes have been added.', student.enroll('a', notes, 'Y'))
        self.assertEqual({'a': notes}, student.courses)

    def test_enroll_when_course_not_in_courses_and_add_courses_notes_empty_string_expect_append_courses_and_notes(self):
        student = Student('Name')
        notes = ['b', 'c', 'd']
        self.assertEqual('Course and course notes have been added.', student.enroll('a', notes, ''))
        self.assertEqual({'a': notes}, student.courses)

    def test_enroll_when_course_not_in_courses_and_add_courses_notes_not_empty_string_or_Y_expect_append_courses_and_notes(self):
        student = Student('Name')
        notes = ['b', 'c', 'd']
        self.assertEqual('Course has been added.', student.enroll('a', notes, 'v'))
        self.assertEqual({'a': []}, student.courses)

    def test_add_notes_when_course_exist_expect_append_notes_return_message(self):
        student = Student('Name', {'a': ['a']})

        self.assertEqual('Notes have been updated', student.add_notes('a', 'b'))
        self.assertEqual({'a': ['a', 'b']}, student.courses)

    def test_add_notes_when_course_not_exist_expect_append_exception(self):
        student = Student('Name')
        with self.assertRaises(Exception) as ex:
            student.add_notes('a', 'b')

        self.assertEqual('Cannot add notes. Course not found.', str(ex.exception))

    def test_leave_courses_when_course_exist_expect_remove_course_and_make_message(self):
        student = Student('Name', {'a': []})
        self.assertEqual('Course has been removed', student.leave_course('a'))
        self.assertEqual({}, student.courses)

    def test_leave_courses_when_course_not_exist_expect_exception(self):
        student = Student('Name')
        with self.assertRaises(Exception) as ex:
            student.leave_course('a')

        self.assertEqual('Cannot remove course. Course not found.', str(ex.exception))


if __name__ == '__main__':
    main()