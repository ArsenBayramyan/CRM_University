﻿using CRM_University.Core.Interfaces;
using CRM_University.Data.Contexts;

namespace CRM_University.Data.Repositories
{
    public class UnitOfWorkRepository:IUnitOfWorkRepository
    {
        private StudentRepository _studentRepository;
        private AssessmentRepository _assessmentRepository;
        private ExaminationRepository _examinationRepository;
        private FacultyRepository _facultyRepository;
        private GroupRepository _groupRepository;
        private StudentSubjectRepository _studentSubjectRepository;
        private SubjectRepository _subjectRepository;
        private TutionRepository _tutionRepository;
        private UnpaidStudentsRepository _unpaidStudentRepository;
        private FrequenciyRepository _frequenciyRepository;
        private NotReceivedRepository _notReceivedRepository;
        private DiscountStudentRepository _discountStudentRepository;
        public UnitOfWorkRepository(ApplicationDBContext context)
        {
            _studentRepository = new StudentRepository(context);
            _assessmentRepository = new AssessmentRepository(context);
            _examinationRepository = new ExaminationRepository(context);
            _facultyRepository = new FacultyRepository(context);
            _groupRepository = new GroupRepository(context);
            _studentSubjectRepository = new StudentSubjectRepository(context);
            _subjectRepository = new SubjectRepository(context);
            _tutionRepository = new TutionRepository(context);
            _unpaidStudentRepository = new UnpaidStudentsRepository(context);
            _frequenciyRepository = new FrequenciyRepository(context);
            _notReceivedRepository = new NotReceivedRepository(context);
            _discountStudentRepository = new DiscountStudentRepository(context);
        }

        public StudentRepository StudentRepository => _studentRepository;
        public AssessmentRepository AssessmentRepository => _assessmentRepository;
        public ExaminationRepository ExaminationRepository => _examinationRepository;
        public FacultyRepository FacultyRepository => _facultyRepository;
        public GroupRepository GroupRepository => _groupRepository;
        public StudentSubjectRepository StudentSubjectRepository => _studentSubjectRepository;
        public SubjectRepository SubjectRepository => _subjectRepository;
        public TutionRepository TutionRepository => _tutionRepository;
        public UnpaidStudentsRepository UnpaidStudentsRepository => _unpaidStudentRepository;
        public FrequenciyRepository FrequenciyRepository => _frequenciyRepository;
        public NotReceivedRepository NotReceivedRepository => _notReceivedRepository;
        public DiscountStudentRepository DiscountStudentRepository => _discountStudentRepository;

    }
}
